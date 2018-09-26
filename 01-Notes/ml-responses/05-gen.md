# General

## Error response
```json
{
    "status": 400,
    "error": "malformed JSON detected, please lint your request params"
}
```

## Sample codes
- http Code used by Postman
	```
	GET /api/v1/posts?include=replies,story,user,workspace HTTP/1.1
	Host: api.mavenlink.com
	Content-Type: application/json
	Authorization: Bearer c41aeb7dc6e29f4fdd6ecaed44a1ea7f1f627578d216107a6ac2548f7cccd876
	Cache-Control: no-cache
	Postman-Token: 114378ad-0494-4c58-bab2-51eaaab72845
	```

- http Code used by Postman
	```
	POST /api/v1/posts?include=replies,story,user,workspace HTTP/1.1
	Host: api.mavenlink.com
	Content-Type: application/json
	Authorization: Bearer c41aeb7dc6e29f4fdd6ecaed44a1ea7f1f627578d216107a6ac2548f7cccd876
	Cache-Control: no-cache
	Postman-Token: 98f5a99c-b5b1-4f39-9258-d1f414008f8e

	{
	"post": {
		"workspace_id": 22422665,
		"message": "Sample post to test request format"
	}
	}
	```

- cURL code
	```
	curl --request POST \
	--url 'https://api.mavenlink.com/api/v1/posts?include=replies,story,user,workspace' \
	--header 'Authorization: Bearer c41aeb7dc6e29f4fdd6ecaed44a1ea7f1f627578d216107a6ac2548f7cccd876' \
	--header 'Cache-Control: no-cache' \
	--header 'Content-Type: application/json' \
	--header 'Postman-Token: 5f523d3d-9bab-4bdf-a8cd-83fea430ca5c' \
	--data '{\n  "post": {\n    "workspace_id": 22422665,\n    "message": "Sample post to test request format"\n  }\n}\n'
	```

- wget code
	```
	wget --quiet \
	--method POST \
	--header 'Content-Type: application/json' \
	--header 'Authorization: Bearer c41aeb7dc6e29f4fdd6ecaed44a1ea7f1f627578d216107a6ac2548f7cccd876' \
	--header 'Cache-Control: no-cache' \
	--header 'Postman-Token: 796784fb-41a7-4f4d-880f-b8b594478c1f' \
	--body-data '{\n  "post": {\n    "workspace_id": 22422665,\n    "message": "Sample post to test request format"\n  }\n}\n' \
	--output-document \
	- 'https://api.mavenlink.com/api/v1/posts?include=replies,story,user,workspace'
	```
