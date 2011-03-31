namespace CHSNS.Interface {
	public interface IEmail {
		void Send(string to, string from, string subject, string body, string username, string password, string smtpHost);
	}
}
