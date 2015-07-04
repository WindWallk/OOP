namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    public class BestAnswer : Answers
    {
        public BestAnswer(int id, string body, IUser aouthor) 
            : base(id, body, aouthor)
        {
        }

        public override string ToString()
        {
            //********************
            //[Answer ID: { id} ]
            //Posted by: { author}
            //Answer Body: { body}
            //--------------------
            //********************
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('*', 20));
            sb.AppendLine(base.ToString());
            sb.AppendLine(new string('*', 20));

            return sb.ToString().Trim();
        }
    }
}
