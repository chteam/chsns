using System.Collections.Generic;
using CHSNS.Models;

namespace CHSNS.Operator{
	public interface IAlbumOperator{
	    List<Album> Items(long uId);
        Album Get(long id);
        void Add(Album album, long uId);
        void Update(Album album);
        List<Photo> GetPhotos(long id, long uId, int page, int pageSize);
        Album GetCountChange(long id, int num);
	}
}