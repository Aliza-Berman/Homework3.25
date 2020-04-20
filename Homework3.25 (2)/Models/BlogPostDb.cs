using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Homework3._25__2_.Models
{
    public class BlogPostDb
    {
        private string _connectionString;
        public BlogPostDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Post> GetPosts(int skip, int amount)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"SELECT * FROM BlogPost";
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Post> results = new List<Post>();
                while (reader.Read())
                {
                    results.Add(GetFromReader(reader));
                }

                return results;

            }
        }

            public void AddPost(Post post)
            {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {

                cmd.CommandText = "INSERT INTO Posts (Title, BlogContent, DateCreated) " +
                                      "VALUES (@title, @content, @date) SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@title", post.Title);
                cmd.Parameters.AddWithValue("@content", post.BlogContent);
                cmd.Parameters.AddWithValue("@date", post.DateSubmitted);
                connection.Open();
                post.Id = (int)(decimal)cmd.ExecuteScalar();
            }
            }
        public Post GetPost(int postId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Posts WHERE Id = @id";
                command.Parameters.AddWithValue("@id", postId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }

                return GetFromReader(reader);
            }
        }
        private Post GetFromReader(SqlDataReader reader)
        {
            Post post = new Post();
            post.Id = (int)reader["Id"];
            post.Title = (string)reader["Title"];
            post.BlogContent = (string)reader["BlogContent"];
            post.DateSubmitted = (DateTime)reader["DateSubmitted"];
            return post;
        }
        public List<Comment> GetComments(int PostId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"SELECT * FROM Comments WHERE Postid = @id";
                cmd.Parameters.AddWithValue("@id", PostId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Comment> results = new List<Comment>();
                while (reader.Read())
                {
                    Comment comment = new Comment();
                    comment.Id = (int)reader["Id"];
                    comment.Name = (string)reader["Name"];
                    comment.CommentContent = (string)reader["Comment"];
                    comment.DateSubmitted = (DateTime)reader["DateSubmitted"];
                    comment.PostId = (int)reader["PostId"];
                    results.Add(comment);
                }

                return results;

            }
        }
        public void AddComment(Comment comment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Comments (Name, Comment, DateSubmitted, PostId) " +
                                      "VALUES (@name, @comment, @date, @postId)";
                command.Parameters.AddWithValue("@name", comment.Name);
                command.Parameters.AddWithValue("@comment", comment.CommentContent);
                command.Parameters.AddWithValue("@date", comment.DateSubmitted);
                command.Parameters.AddWithValue("@postId", comment.PostId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        }
    }

