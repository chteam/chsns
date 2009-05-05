using System;
using CHSNS.Abstractions;

namespace CHSNS.Model {
   public  class AlbumImplement:IAlbum {
       public long Id { get; set; }
       public string Name { get; set; }
       public string Location { get; set; }
       public string Description { get; set; }
       public DateTime AddTime { get; set; }
       public string FaceUrl { get; set; }
       public int Count { get; set; }
       public long UserId { get; set; }
       public int Order { get; set; }
       public byte ShowLevel { get; set; }
   }
}
