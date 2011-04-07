namespace CHSNS
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    using Service;
    public class ServicesFactory
    {
        public ServicesFactory()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            var batch = new CompositionBatch();
            batch.AddPart(this);
            container.Compose(batch);
        }
 
        [Import]
        public AccountService Account { get; private set; }
        [Import]
        public ViewService View { get; private set; }
        [Import]
        public CommentService Comment { get; private set; }
        [Import]
        public GatherService Gather { get; private set; }
        [Import]
        public GroupService Group { get; private set; }
        [Import]
        public UserService UserInfo { get; private set; }
        [Import]
        //c GolbalService Golbal { get { return
        public FriendService Friend { get; private set; }
        [Import]
        public ApplicationService Application { get; private set; }
        [Import]
        public MessageService Message { get; private set; }
        [Import]
        public NoteService Note { get; private set; }
        [Import]
        public EventService Event { get; private set; }
        [Import]
        public AlbumService Album { get; private set; }
        [Import]
        public PhotoService Photo { get; private set; }
        [Import]
        public VideoService Video { get; private set; }
        [Import]
        public EntryService Entry { get; private set; }
 
    }
}
