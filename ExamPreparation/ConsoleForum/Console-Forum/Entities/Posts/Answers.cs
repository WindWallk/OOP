namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    public class Answers : Post, IAnswer
    {
        public Answers(int id, string body, IUser aouthor)
            : base(id, body, aouthor)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("[ Answer ID: {0} ]", this.Id));
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("Answer Body: {0}", this.Body));
            sb.AppendLine(new string('-', 20));

            return sb.ToString().Trim();
        }
    }
}
