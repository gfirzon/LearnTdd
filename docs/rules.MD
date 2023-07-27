## Approve or disapprove house credit application for a single user.

### Busines Rules:
1. Figure out max loan amount
	a. If there is no credit bureau info for user's SSN:
		up to maximum of 30% of anual salary on the application -> max loan amount
	b. Else If credit history has score < 700 for user's SSN:
		up to maximum of 50% of anual salary on the application -> max loan amount
	c. Else If credit history has score >= 700 for user's SSN:
		up to maximum of 100% of anual salary on the application -> max loan amount

2. Decision: Amount requested cannot exceed max approved loan amount
