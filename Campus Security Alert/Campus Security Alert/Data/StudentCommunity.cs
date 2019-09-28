using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Campus_Security_Alert.Classes;
using Campus_Security_Alert.FirebaseHelper;
using Firebase.Database;

namespace Campus_Security_Alert.Data
{
    class StudentCommunity: Java.Lang.Object, IValueEventListener
    {
        List<Messages> MsgList = new List<Messages>();
        public event EventHandler<GetChatsArgs> RetrivedChats;
        public class GetChatsArgs : EventArgs
        {
            public List<Messages> Chats { get; set; }
        }
        public void CreateData()
        {
            var DBRef = FirebaseDB.GetFirebaseDatabase().GetReference("Users")
                .AddValueEventListener(this);
        }

        public void OnCancelled(DatabaseError error)
        {
            
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                foreach (DataSnapshot data in child)
                {
                    Messages chat = new Messages
                    {
                        Msg = data.Child("Msg").Value.ToString(),
                        KeyId = data.Key.ToString(),
                        SenderName = data.Child("SenderName").Value.ToString()
                    };
                MsgList.Add(chat);
                }
                RetrivedChats.Invoke(this, new GetChatsArgs { Chats = MsgList });
            }
        }
    }
}