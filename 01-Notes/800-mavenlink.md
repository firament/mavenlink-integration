# Mavenlink
- https://www.mavenlink.com/
- Mavenlink API documentation
	- http://developer.mavenlink.com/beta/

## API Calls
- Schema
	- Requests must be sent via HTTPS and can be in either 
		- JSON
		- Rails structured x-www-form-urlencoded
- base API URL
	- https://api.mavenlink.com/api/v1/
- Authentication
	- must be authenticated with an OAuth bearer token
	- authenticate using the `Authorization` header, set the header's value to Bearer `<token>`
	- e.g. `curl -H "Authorization: Bearer abc123" "https://api.mavenlink.com/api/v1/workspaces.json"`
- Rate limiting
	- reply has "HTTP code 429 'Too Many Requests'"


## Schema parts

### Errors
```json
{
  errors: [
    {
      type: "oauth"
      message: "Invalid OAuth 2 Request"
    }
  ]
}
```

### Response Format
- always use the returned results array to retrieve the canonical results from an API request.
	```json
	{
	"count": 2,
	"results": [{ key: "workspaces", id: "10" }, { key: "workspaces", id: "11" }],
	"workspaces": {
		"10": {
		id: "10",
		title: "some project",
		participant_ids: ["2", "6"],
		primary_counterpart_id: "6"
	},
		"11": {
		id: "11",
		title: "another project",
		participant_ids: ["2", "8"],
		primary_counterpart_id: "8"
	}
	},
	"users": {
		"2": { id: "2", full_name: "bob" },
		"6": { id: "6", full_name: "chaz" },
		"8": { id: "8", full_name: "jane" }
	}
	}
	```


## OAuth 2.0 Workflow

### Registering your application
- Register and manage OAuth2 applications that can connect to Mavenlink 
- at the application management page as a Mavenlink account administrator.
- Applications have a name and a callback URL for OAuth2.
- https://app.mavenlink.com/oauth/applications

### Obtaining tokens for users
1. Send your user to https://app.mavenlink.com/oauth/authorize with the REQUIRED parameters client_id, response_type, and redirect_uri.
    - client_id is the ID assigned to your application by Mavenlink
    - response_type must be set to "code"
    - redirect_uri must be set to a URL where your application can accept codes and then exchange them for access tokens. It should match the redirect_uri specified when you registered your application.
    - Error as query parms
    - `$REDIRECT_URI?error=access_denied&error_description=The+resource+owner+or+authorization+server+denied+the+request.`
2. Get User Authorization
	- If the user allows your application, then Mavenlink will redirect to the redirect_uri with query parameters providing your application with a time-limited code that your application can exchange for an access token within the next 5 minutes.
	- `$REDIRECT_URI?code=abc123`
3. exchanges the code for an access token
	- make a POST request directly to Mavenlink at https://app.mavenlink.com/oauth/token to exchange the code for an access token
	- request must include the client_id, client_secret, grant_type, code, and redirect_uri parameters
    	- `client_id` is the ID assigned to your application by Mavenlink
    	- `client_secret` is the secret token assigned to your application by Mavenlink
    	- `grant_type` must be set to "authorization_code" in order to exchange a code for an access token
    	- `code` is the value that was returned in the code query parameter when Mavenlink redirected back to your redirect_uri
    	- `redirect_uri` is the exact same value that you used in the original request to /oauth/authorize
4. response body, encoded in JSON, containing access_token and token_type
    - `access_token` is the token that your application will use to authenticate requests to the Mavenlink API as this user
    - `token_type` will be "bearer"
    - Error in the response body, encoded as JSON
5. uses the access token to make authenticated requests
