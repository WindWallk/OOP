namespace ConsoleForum.Entities.Posts
{
    using System;
    using Contracts;

    public abstract class Post : IPost
    {
        private int id;
        private string body;
        private IUser author;

        public Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("id", "The post ID cannot be negative or 0!");
                }
                this.id = value;
            }
        }

        public string Body
        {
            get
            {
                return this.body;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("body", "The body cannot be empty!");
                }

                this.body = value;
            }
        }

        public IUser Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("author", "Author cannot be empty!");
                }

                this.author = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Posted by: {0}", this.Author.Username);
        }
    }
}
