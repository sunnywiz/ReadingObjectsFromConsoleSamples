using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingObjectsFromConsoleSamples
{
    class Program
    {
        private static List<BlogPost> _blogposts;

        static void Main(string[] args)
        {
            _blogposts = new List<BlogPost>()
            {
                new BlogPost()
                {
                    Title = "Test Blog Post",
                    Description = "I made this one so i didn't have to type at first. "
                }
            };
            while (true)
            {
                Console.WriteLine("A = Add a blog post");
                Console.WriteLine("L = List blog posts");
                Console.WriteLine("Q = Quit");

                var choice = Console.ReadLine();
                if (choice == null) continue;
                choice = choice.Trim().ToUpperInvariant();
                switch (choice)
                {
                    case "L":
                        DoList();
                        continue;
                    case "A":
                        DoAdd();
                        continue;
                    case "Q":
                        break; 
                }

            }
        }

        private static void DoAdd()
        {
            var blogPost = BlogPost.ReadFromConsole();
            if (blogPost != null)
            {
                _blogposts.Add(blogPost);
            }
            else
            {
                Console.WriteLine("Didn't successfully read in the blogpost.");
            }
        }

        private static void DoList()
        {
            foreach (var blogpost in _blogposts)
            {
                Console.WriteLine(blogpost);
            }
        }
    }

    public class BlogPost
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Title: {0}", Title);
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("Description: {0}", Description);
            stringBuilder.AppendLine();
            return stringBuilder.ToString(); 
        }

        public static BlogPost ReadFromConsole()
        {
            // This could get as complicated as you wanted it to .. with validation, editing-before-saving, etc.

            Console.WriteLine("Enter Your Title: ");
            var title = Console.ReadLine(); 

            Console.WriteLine("Enter your Description: ");
            var description = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Either Title or Description are empty.  Not valid");
                return null;
            }
            else
            {
                var blogPost = new BlogPost() {Title = title, Description = description};
                return blogPost; 
            }
        }
    }
}
