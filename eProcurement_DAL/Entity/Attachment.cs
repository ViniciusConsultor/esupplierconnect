using System;
using System.Collections.Generic;
using System.Text;

namespace eProcurement_DAL
{
    [Serializable]
    public class Attachment
    {
        Guid attachmentId;
        public Guid AttachmentId
        {
            get { return attachmentId; }
            set { attachmentId = value; }
        }

        string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        string fileDesc;
        public string FileDesc
        {
            get { return fileDesc; }
            set { fileDesc = value; }
        }

        long fileSize;
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        private byte[] fileData;
        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }

        long attachDate;
        public long AttachDate
        {
            get { return attachDate; }
            set { attachDate = value; }
        }

        string storePath;
        public string StorePath
        {
            get { return storePath; }
            set { storePath = value; }
        }

        string profileType;
        public string ProfileType
        {
            get { return profileType; }
            set { profileType = value; }
        }

        string createBy;
        public string CreateBy
        {
            get { return createBy; }
            set { createBy = value; }
        }

        string delInd;
        public string DelInd
        {
            get { return delInd; }
            set { delInd = value; }
        }

        string rfqNumber;
        public string RfqNumber
        {
            get { return rfqNumber; }
            set { rfqNumber = value; }
        }
	
    }
}
