Feature: Coronal Mass Ejection (CME) Endpoint

Verifying the responses of CME endpoint

@smoke
  Scenario Outline: Verify GET endpoint returns success
	Given I call the GET CME API with startDate "<startDate>" and endDate "<endDate>"
    Then I should receive a valid response with CME data
    Examples: 
	| startDate  | endDate    | Duration |
	| 2024-01-01 | 2024-01-02 | 1 day    |
	| 2024-01-01 | 2024-01-05 | 5 days   |
	| 2024-01-01 | 2024-01-31 | 30 days  |

@validation @skip
  Scenario Outline: Verify invalid date format returns 400
    Given I call the GET CME API with startDate "<startDate>" and endDate "<endDate>"
	Then I should receive a Bad Request response
	# API is not validating any different formats, even when text is used as date or no date parameters specified ???
	# Response is always 200 returning data from 2025-04-06T04:00Z
	Examples:
	| startDate  | endDate    |
	| 01-01-2024 | 01-02-2024 |
	| 2024/01/01 | 2024/01/02 |