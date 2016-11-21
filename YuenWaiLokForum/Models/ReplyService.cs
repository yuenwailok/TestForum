using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuenWaiLokForum.Models
{
    public class ReplyService
    {

        private void arrangeRepply(ReplyViewModel reply1, ReplyViewModel reply2)
        {
            if (reply1.id == reply2.LinkedReply_id && !reply2.Added)
            {
                reply1.replies.Add(reply2);
                reply2.Added = true;
            }

            for (int i = 0; i < reply1.replies.Count; i++)
            {
                arrangeRepply(reply1.replies[i], reply2);
            }
        }

        public void insertReply(Thread th, ThreadDetailViewModel threadDetail)
        {
            var temp = new List<ReplyViewModel>();

            foreach (var reply in th.Replies)
            {
                var replyDetail = new ReplyViewModel
                {
                    id = reply.R_Id,
                    Author = reply.Author,
                    Content = reply.Content,
                    Date = reply.DateTime,
                    Title = reply.Title,
                    LinkedReply_id = reply.LinkedReply_Id,
                    replies = new List<ReplyViewModel>()

                };

                temp.Add(replyDetail);
            }

            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    arrangeRepply(temp[i], temp[j]);
                }

                if (temp[i].LinkedReply_id == null)
                {
                    threadDetail.replies.Add(temp[i]);
                }
            }
        }
    }
}