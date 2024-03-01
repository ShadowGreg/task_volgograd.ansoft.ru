CREATE DATABASE 'D:\\data.fdb' page_size 8192
        user 'SYSDBA' password 'masterkey';

CONNECT 'data.fdb' USER 'SYSDBA' PASSWORD 'masterkey';

SET SQL DIALECT 3;

CREATE TABLE Messages (
                          MessageId UUID PRIMARY KEY,
                          Email VARCHAR(255),
                          PhoneNumber VARCHAR(20),
                          MessageType VARCHAR(50),
                          Subject VARCHAR(255),
                          Content BLOB SUB_TYPE TEXT,
                          SendResult VARCHAR(100)
);


CREATE TABLE Attachments (
                             AttachmentId  UUID PRIMARY KEY,
                             MessageId UUID,
                             AttachmentFile BLOB,
                             FOREIGN KEY (MessageId) REFERENCES Messages(MessageId)
);