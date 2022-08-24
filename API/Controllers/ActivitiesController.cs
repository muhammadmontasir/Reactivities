using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        // enabling user to select individual activity. that means when someone is asking
        // for a single activity they'll go to the activities endpoint, then they will pass
        // in the id, whatever the id of the activity they want to fetch.
        
        [HttpGet("{id}")] //passing a parameter activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
            // this is going to find an activity with an ID that matches what we're passing in there.
        }

    }
}