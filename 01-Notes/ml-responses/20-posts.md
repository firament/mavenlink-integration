# Get
## Request
```
posts?include=replies,story,user,workspace
```

## Response
```json
{
  "count": 3,
  "results": [
    {
      "key": "posts",
      "id": "195565525"
    },
    {
      "key": "posts",
      "id": "195567675"
    },
    {
      "key": "posts",
      "id": "195565485"
    }
  ],
  "posts": {
    "195565525": {
      "newest_reply_at": "2018-09-18T15:55:48+05:30",
      "message": "Second post to inspect response.",
      "formatted_message": "<p>Second post to inspect response.</p>",
      "parsed_message": "Second post to inspect response.",
      "has_attachments": false,
      "created_at": "2018-09-18T15:09:40+05:30",
      "updated_at": "2018-09-18T15:55:48+05:30",
      "reply_count": 1,
      "reply": false,
      "private": false,
      "subject_title": null,
      "subject_id": null,
      "subject_type": null,
      "subject_ref": null,
      "user_id": "10482805",
      "workspace_id": "22422665",
      "story_id": null,
      "id": "195565525"
    },
    "195567675": {
      "newest_reply_at": null,
      "message": "Added reply from website.",
      "formatted_message": "<p>Added reply from website.</p>",
      "parsed_message": "Added reply from website.",
      "has_attachments": false,
      "created_at": "2018-09-18T15:55:48+05:30",
      "updated_at": "2018-09-18T15:55:48+05:30",
      "reply_count": 0,
      "reply": true,
      "private": false,
      "subject_title": null,
      "subject_id": 195565525,
      "subject_type": "Post",
      "subject_ref": {
        "id": "195565525",
        "key": "posts"
      },
      "user_id": "10482805",
      "workspace_id": "22422665",
      "story_id": null,
      "id": "195567675"
    },
    "195565485": {
      "newest_reply_at": null,
      "message": "Sample post created from postman",
      "formatted_message": "<p>Sample post created from postman</p>",
      "parsed_message": "Sample post created from postman",
      "has_attachments": false,
      "created_at": "2018-09-18T15:08:34+05:30",
      "updated_at": "2018-09-18T15:08:34+05:30",
      "reply_count": 0,
      "reply": false,
      "private": false,
      "subject_title": null,
      "subject_id": null,
      "subject_type": null,
      "subject_ref": null,
      "user_id": "10482805",
      "workspace_id": "22422665",
      "story_id": null,
      "id": "195565485"
    }
  },
  "meta": {
    "count": 3,
    "page_count": 1,
    "page_number": 1,
    "page_size": 20
  }
}
```

# POST
## Request
```json
{
  "post": {
    "workspace_id": 22422665,
    "message": "Sample post to test app code posts"
  }
}
```

## Response
### 1 - bare
```json
{
    "count": 1,
    "results": [
        {
            "key": "posts",
            "id": "196700365"
        }
    ],
    "posts": {
        "196700365": {
            "newest_reply_at": null,
            "message": "Sample post to test request format",
            "formatted_message": "<p>Sample post to test request format</p>",
            "parsed_message": "Sample post to test request format",
            "has_attachments": false,
            "created_at": "2018-09-24T03:09:54-07:00",
            "updated_at": "2018-09-24T03:09:54-07:00",
            "reply_count": 0,
            "reply": false,
            "private": false,
            "subject_title": null,
            "subject_id": null,
            "subject_type": null,
            "subject_ref": null,
            "user_id": "10482805",
            "workspace_id": "22422665",
            "story_id": null,
            "id": "196700365"
        }
    },
    "meta": {
        "count": 1,
        "page_count": 1,
        "page_number": 1,
        "page_size": 20
    }
}
```

### 2 - `?include=replies,story,user,workspace`
```json
{
    "count": 1,
    "results": [
        {
            "key": "posts",
            "id": "196700395"
        }
    ],
    "posts": {
        "196700395": {
            "newest_reply_at": null,
            "message": "Sample post to test request format",
            "formatted_message": "<p>Sample post to test request format</p>",
            "parsed_message": "Sample post to test request format",
            "has_attachments": false,
            "created_at": "2018-09-24T03:10:36-07:00",
            "updated_at": "2018-09-24T03:10:36-07:00",
            "reply_count": 0,
            "reply": false,
            "private": false,
            "subject_title": null,
            "subject_id": null,
            "subject_type": null,
            "subject_ref": null,
            "user_id": "10482805",
            "workspace_id": "22422665",
            "story_id": null,
            "reply_ids": [],
            "id": "196700395"
        }
    },
    "meta": {
        "count": 1,
        "page_count": 1,
        "page_number": 1,
        "page_size": 20
    },
    "stories": {},
    "users": {
        "10482805": {
            "full_name": "sajid",
            "photo_path": "https://app.mavenlink.com/images/default_profile_photo/default.png",
            "email_address": "sajid@hardwinsoftware.com",
            "headline": null,
            "generic": false,
            "disabled": false,
            "update_whitelist": [
                "full_name",
                "headline",
                "email_address",
                "external_reference"
            ],
            "account_id": "5457855",
            "id": "10482805"
        }
    },
    "workspaces": {
        "22422665": {
            "title": "alpha trail",
            "account_id": 5457855,
            "archived": false,
            "description": "A trail project to evaluate integrations and ustom forms.",
            "due_date": "2018-09-28",
            "effective_due_date": "2018-09-28",
            "start_date": "2018-09-24",
            "budgeted": false,
            "change_orders_enabled": false,
            "updated_at": "2018-09-24T03:10:36-07:00",
            "created_at": "2018-09-18T01:51:05-07:00",
            "consultant_role_name": "Consultants",
            "client_role_name": "Clients",
            "percentage_complete": 0,
            "access_level": "open",
            "exclude_archived_stories_percent_complete": false,
            "can_create_line_items": false,
            "default_rate": null,
            "currency": "USD",
            "currency_symbol": "$",
            "currency_base_unit": 100,
            "can_invite": true,
            "has_budget_access": false,
            "tasks_default_non_billable": false,
            "rate_card_id": null,
            "workspace_invoice_preference_id": null,
            "posts_require_privacy_decision": false,
            "require_time_approvals": false,
            "require_expense_approvals": false,
            "has_active_timesheet_submissions": false,
            "has_active_expense_report_submissions": false,
            "update_whitelist": [
                "title",
                "budgeted",
                "start_date",
                "due_date",
                "description",
                "currency",
                "access_level",
                "consultant_role_name",
                "client_role_name",
                "rate_card_id",
                "exclude_archived_stories_percent_complete",
                "tasks_default_non_billable",
                "stories_are_fixed_fee_by_default",
                "change_orders_enabled",
                "expenses_in_burn_rate",
                "posts_require_privacy_decision",
                "status_key",
                "invoice_preference",
                "approver_id",
                "approver_ids",
                "workspace_group_ids",
                "project_template_start_date",
                "project_template_assignment_mappings",
                "project_template_weekends_as_workdays",
                "project_template_create_unnamed_resources",
                "project_tracker_template_id",
                "target_margin",
                "external_reference",
                "account_color_id",
                "archived",
                "price",
                "project_template_before_story_id"
            ],
            "account_features": {
                "time_trackable": false,
                "has_time_entry_role_picker": false,
                "project_side_panel": false
            },
            "permissions": {
                "can_upload_files": true,
                "can_private_message": true,
                "can_join": false,
                "is_participant": true,
                "access_level": "admin",
                "team_lead": true,
                "user_is_client": false,
                "can_change_price": false,
                "can_change_story_billable": true,
                "can_post": true,
                "can_edit": true,
                "restricted": false,
                "can_see_financials": true
            },
            "price_in_cents": null,
            "price": "TBD",
            "percent_of_budget_used": 0,
            "budget_used": "$0",
            "budget_used_in_cents": 0,
            "budget_remaining": null,
            "target_margin": null,
            "stories_are_fixed_fee_by_default": false,
            "creator_id": "10482805",
            "primary_maven_id": "10482805",
            "id": "22422665"
        }
    }
}
```
