# VCA S3 Storage Service Notes

> ## Storage
>
> - at a request we can send 5TB data in S3.
> -
> -

> ## versioning
>
> - versioning is possible in S3 with additional billing.
> - we can access specific version file.
> -

> ## Speed
>
> - S3 Transfer Acceleration will provides faster upload with additional billing.
> -
> -

> ## code for cancelling all inProgress multipart request
>
> ```c#
> var list = await _s3Client.ListMultipartUploadsAsync(_s3Creds.BucketName);
>
>            foreach (var item in list.MultipartUploads)
>            {
>
>                var abortRequest = new AbortMultipartUploadRequest
>                {
>                    BucketName = list.BucketName,
>                    Key = item.Key,
>                    UploadId = item.UploadId,
>                };
>                var r = await _s3Client.AbortMultipartUploadAsync(abortRequest);
>            }
> ```

> ## code for multipart upload request in s3

> ```c#
> public async Task MultipartlUploadFile(UploadDocumentDetails documentDetails)
>        {
>            var initiateRequest = new InitiateMultipartUploadRequest
>            {
>                BucketName = _s3Creds.BucketName,
>                Key = $"{documentDetails.StoragePath}/{documentDetails.DocumentName}"
>            };
>
>            var initiateResponse = await _s3Client.InitiateMultipartUploadAsync(initiateRequest);
>
>            var uploadId = initiateResponse.UploadId;
>
>            var partSize = 5 * 1024 * 1024;
>
>            var buffer = new byte[partSize];
>
>            int bytesRead;
>
>            var partNumbers = new List<PartETag>();
>
>            for (var i = 1; (bytesRead = await documentDetails.DocumentStream.ReadAsync(buffer, 0, buffer.Length)) > 0; i++)
>            {
>                var uploadPartRequest = new UploadPartRequest
>                {
>                    BucketName = _s3Creds.BucketName,
>                    Key = $"{documentDetails.StoragePath}/{documentDetails.DocumentName}",
>                    UploadId = uploadId,
>                    PartNumber = i,
>                    PartSize = bytesRead,
>                    InputStream = new MemoryStream(buffer, 0, bytesRead)
>                };
>
>                var uploadPartResponse = await _s3Client.UploadPartAsync(uploadPartRequest);
>
>                partNumbers.Add(new PartETag(uploadPartResponse.PartNumber, uploadPartResponse.ETag));
>            }
>
>            var completeRequest = new CompleteMultipartUploadRequest
>            {
>                BucketName = _s3Creds.BucketName,
>                Key = $"{documentDetails.StoragePath}/{documentDetails.DocumentName}",
>                UploadId = uploadId,
>                PartETags = partNumbers
>            };
>
>            ListPartsRequest listPartRequest = new ListPartsRequest
>            {
>                BucketName = _s3Creds.BucketName,
>                Key = $"{documentDetails.StoragePath}/{documentDetails.DocumentName}",
>                UploadId = uploadId,
>            };
>            ListPartsResponse listPartResponse = await _s3Client.ListPartsAsync(listPartRequest);
>
>
>            if (partNumbers.Count == listPartResponse.Parts.Count)
>            {
>                var completeResponse = await _s3Client.CompleteMultipartUploadAsync(completeRequest);
>            }
>
>           var list = await _s3Client.ListMultipartUploadsAsync(_s3Creds.BucketName);
>
>            foreach (var item in list.MultipartUploads)
>            {
>
>                var abortRequest = new AbortMultipartUploadRequest
>                {
>                    BucketName = list.BucketName,
>                    Key = item.Key,
>                    UploadId = item.UploadId,
>                };
>                var r = await _s3Client.AbortMultipartUploadAsync(abortRequest);
>            }
>        }
> ```
