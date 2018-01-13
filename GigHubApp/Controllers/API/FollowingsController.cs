using GigHubApp.Core;
using GigHubApp.Core.DTOs;
using GigHubApp.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHubApp.Controllers.API
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        //private GigHubContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            //_context = new GigHubContext();
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDTO dto)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(userId, dto.FolloweeId);

            //if (_context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId))
            if (following != null)
                return BadRequest("Following already exists.");

            following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            //_context.Followings.Add(following);
            //_context.SaveChanges();
            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();

            //var following = _context.Followings
            //    .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == id);

            var following = _unitOfWork.Followings.GetFollowing(userId, id);

            if (following == null)
                return NotFound();

            //_context.Followings.Remove(following);
            //_context.SaveChanges();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
