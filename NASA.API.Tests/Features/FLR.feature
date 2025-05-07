Feature: Solar Flare (FLR) Endpoint

Verifying the responses of FLR endpoint

@smoke
  Scenario Outline: Verify GET endpoint returns success
	Given I call the GET FLR API with startDate "<startDate>" and endDate "<endDate>"
    Then I should receive a valid response with FLR data
    Examples: 
	| startDate  | endDate    | Duration |
	| 2024-01-01 | 2024-01-02 | 1 day    |
	| 2024-01-01 | 2024-01-05 | 5 days   |
	| 2024-01-01 | 2024-01-31 | 30 days  |

@validation @skip
## Bad Request response is not returned for missing/invalid date formats
  Scenario Outline: Verify missing start date returns 400
    Given I call the GET FLR API with startDate "<startDate>" and endDate "<endDate>"
	Then I should receive a Bad Request response
	Examples:
	| startDate | endDate    |
	|           | 2024-01-01 |
	| TEST      | 2024-01-01 |
	| /!~#      | 2024-01-01 |