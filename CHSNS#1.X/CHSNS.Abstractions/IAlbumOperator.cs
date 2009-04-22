using System.Collections.Generic;
using CHSNS.Models;
using CHSNS.Models.Abstractions;

namespace CHSNS.Operator{
	public interface IAlbumOperator{
	    List<IAlbum> Items(long uId);
        IAlbum Get(long id);
        void Add(IAlbum album, long uId);
        void Update(IAlbum album);
        List<IPhoto> GetPhotos(long id, long uId, int page, int pageSize);
        IAlbum GetCountChange(long id, int num);
	}
}