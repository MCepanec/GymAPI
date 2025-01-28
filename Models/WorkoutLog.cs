namespace GymAPI.Models;

    public class WorkoutLog
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public string Exercise { get; set; } = default!;
        public int Duration { get; set; }
        public Member? Member { get; set; }
    }
