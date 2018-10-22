package zad5;

import java.util.LinkedList;
import javax.mail;

public class EmailMessage {

    //required parameters
    private String from; //required (must be e-mail)
    private LinkedList<String> to; //required at least one (must be e-mail)
    //optional parameters
    private String subject; //optional
    private String content; //optional
    private String mimeType;  // optional
    private LinkedList<String> cc; //optional
    private LinkedList<String> bcc; // optional

    public static Builder builder() {
        return new EmailMessage.Builder();
    }


    public EmailMessage(Builder builder) {
        this.from = builder.from;
        this.to = builder.to;
        this.subject = builder.subject;
        this.content = builder.content;
        this.mimeType = builder.mimeType;
        this.cc = builder.cc;
        this.bcc = builder.bcc;
    }

    public void Send(){
        JavaMail
    }


    static public class Builder {
        //required parameters
        private String from;
        private LinkedList<String> to; //required at least one (must be e-mail)
        //optional parameters
        private String subject;
        private String content;
        private String mimeType;
        private LinkedList<String> cc;
        private LinkedList<String> bcc;

        public Builder() {
            to = new LinkedList<>();
            cc = new LinkedList<>();
            bcc = new LinkedList<>();
        }

        public Builder addFrom(String from) {
            this.from = from;
            return this;
        }

        public Builder addTo(String to) {
            this.to.add(to);
            return this;
        }

        public Builder addSubject(String subject) {
            this.subject = subject;
            return this;
        }

        public Builder addContent(String content) {
            this.content = content;
            return this;
        }
        public Builder addMimeTyppe(String mimeType) {
            this.mimeType = mimeType;
            return this;
        }
        public Builder addCc(String cc) {
            this.cc.add(cc);
            return this;
        }
        public Builder addBcc(String bcc) {
            this.bcc.add(bcc);
            return this;
        }


        public EmailMessage build() throws Exception {
            if(this.from != null && this.to.size() > 0) {
                return new EmailMessage(this);
            }
            else {
                throw new Exception("required paramateres needed");
            }

        }

    }
}
