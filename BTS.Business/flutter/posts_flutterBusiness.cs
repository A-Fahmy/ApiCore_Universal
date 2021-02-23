using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.Entities;
using BTS.Data.Repositories;

using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.ServiceModel;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net.Security;
using OdooRpcWrapper;
using XmlRpc;
using Newtonsoft.Json;
using System.Collections;
using System;
using BTS.Entities.flutter;

namespace BTS.Business.flutter
{
    public partial class posts_flutterBusiness
    {
        public static List<post> GetAll_WhatsNews(int id)
        {
            List<post> Ltspost = new List<post>();
            post _Add = new post();
            _Add.id = "1";
            _Add.title = "Dr.";
            _Add.featuredImage = "https://loremflickr.com/640/360";
            _Add.votesDown = 50;
            _Add.votesUp = 80;
            _Add.dateWritten = "2020-09-01 10:10";
            _Add.content = "A witness gave a detailed description of the man";
            _Add.categoryId = 1;
            _Add.userName = "ahmed Fahmy";
            Ltspost.Add(_Add);

            _Add = new post();

            _Add.id = "2";
            _Add.title = "Mrs.";
            _Add.featuredImage = "https://placekitten.com/640/360";
            _Add.votesDown = 10;
            _Add.votesUp = 30;
            _Add.dateWritten = "2020-10-01 10:10";
            _Add.content = "He gave a very vivid and often shocking description of his time in prison";
            _Add.categoryId = 1;
            _Add.userName = "Hany ahmed";
            Ltspost.Add(_Add);


            _Add = new post();
            _Add.id = "3";
            _Add.title = "Dr.";
            _Add.featuredImage = "https://picsum.photos/640/360";
            _Add.votesDown = 11;
            _Add.votesUp = 22;
            _Add.dateWritten = "2020-11-01 10:10";
            _Add.content = "The book contains lyrical descriptions of the author's childhood.";
            _Add.categoryId = 1;
            _Add.userName = "ahmed ahmed";
            Ltspost.Add(_Add);

            _Add = new post();
            _Add.id = "4";
            _Add.title = "Dr.";
            _Add.featuredImage = "https://placebeard.it/640x360";
            _Add.votesDown = 20;
            _Add.votesUp = 10;
            _Add.dateWritten = "2020-11-01 10:10";
            _Add.content = "eporters called the scene “a disaster area,” and I think that was an accurate description.";
            _Add.categoryId = 1;
            _Add.userName = "Tamer ali";
            Ltspost.Add(_Add);

            _Add = new post();
            _Add.id = "5";
            _Add.title = "Dr.";
            _Add.featuredImage = "https://www.stevensegallery.com/640/360";
            _Add.votesDown = 20;
            _Add.votesUp = 15;
            _Add.dateWritten = "2020-12-01 10:10";
            _Add.content = "applied for the position after reading the job description.";
            _Add.categoryId = 1;
            _Add.userName = "Tamer ali";
            Ltspost.Add(_Add);

            _Add = new post();
            _Add.id = "6";
            _Add.title = "Dr.";
            _Add.featuredImage = "https://placebeard.it/640x360";
            _Add.votesDown = 20;
            _Add.votesUp = 15;
            _Add.dateWritten = "2020-11-01 10:10";
            _Add.content = "a writer with a gift of description";
            _Add.categoryId = 1;
            _Add.userName = "Tamer ali";
            Ltspost.Add(_Add);

            _Add = new post();
            _Add.id = "7";
            _Add.title = "Mrs.";
            _Add.featuredImage = "https://baconmockup.com/640/360";
            _Add.votesDown = 21;
            _Add.votesUp = 11;
            _Add.dateWritten = "2020-11-01 10:10";
            _Add.content = "Critics panned the wire service for its hyperbolic description of the McCain endorsement.";
            _Add.categoryId = 1;
            _Add.userName = "ahmed Fahmy";
            Ltspost.Add(_Add);


            _Add = new post();
            _Add.id = "8";
            _Add.title = "Mrs.";
            _Add.featuredImage = "https://www.placecage.com/640/360";
            _Add.votesDown = 21;
            _Add.votesUp = 11;
            _Add.dateWritten = "2020-11-01 10:10";
            _Add.content = "Researchers noticed on Sunday that the agency had updated its description";
            _Add.categoryId = 1;
            _Add.userName = "hany Fahmy";
            Ltspost.Add(_Add);

            _Add = new post();
            _Add.id = "9";
            _Add.title = "Mrs.";
            _Add.featuredImage = "http://placeimg.com/640/360/any";

            _Add.votesDown = 21;
            _Add.votesUp = 11;
            _Add.dateWritten = "2020-11-01 10:10";
            _Add.content = "the virus is transmitted to say that the pathogen is spread primarily";
            _Add.categoryId = 1;
            _Add.userName = "ahmed Fahmy";
            Ltspost.Add(_Add);


            _Add = new post();
            _Add.id = "10";
            _Add.title = "Mrs.";
            _Add.featuredImage = "https://placebeard.it/640x360";
            _Add.votesDown = 22;
            _Add.votesUp = 15;
            _Add.dateWritten = "2020-09-01 10:10";
            _Add.content = "History and Etymology for description";
            _Add.categoryId = 1;
            _Add.userName = "Tamer Fahmy";
            Ltspost.Add(_Add);



            return Ltspost;

        }

    }
}
