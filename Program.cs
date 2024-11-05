using System.Reflection;
using System.Transactions;

Email email1 = new Email();
Email email2 = new Email("joe","robles","hello","hi there, joe here!");

File file1 = new File();
File file2 = new File("C:/user/admin/Downloads/file","hello world");

Console.WriteLine(ContainsKeyword(email1,"robles"));
Console.WriteLine(ContainsKeyword(email2, "robles"));
Console.WriteLine(ContainsKeyword(file1, "file"));
Console.WriteLine(ContainsKeyword(file2, "file"));

static bool ContainsKeyword(Document docObject, string keyword) { return (docObject.ToString().IndexOf(keyword, 0) >= 0); }

class Document {
    private string text;

    public Document(string _t= "example base document text") { text = _t; }

    public virtual string ToString() { return text;  }
    public void setText(string _s) { text = _s; }
}

class Email : Document {
    private string sender;
    private string recipient;
    private string title;

    public Email(string _s="example sender", string _r= "example recipient", string _t= "example title", string body = "example body") : base(body) {
        sender = _s;
        recipient = _r;
        title = _t;
    }

    public string getSender() { return sender; }
    public string getRecipient() { return recipient; }
    public string getTitle() { return title; }

    public void setSender(string _s) { sender = _s; }
    public void setRecipient(string _s) { recipient = _s; }
    public void setTitle(string _s) { title = _s; }

    public override string ToString() {
        return "sender: "+sender+"\nrecipient: "+recipient+"title: \n"+title+"\nbody: "+base.ToString();
    }
}

class File : Document {
    private string pathname;

    public File(string _p="example pathname", string _t="example text") : base(_t) { pathname = _p; }

    public override string ToString() {
        return "File path name: " + pathname +"\nBody: "+ base.ToString();
    }
}