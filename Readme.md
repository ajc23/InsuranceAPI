# Insurance API #

A customer has recently purchased Travel Insurance from an Insurance Company MyInsuranceUK. There is an online Portal which allows the customer to:
* View basic details about the Insurance Policy
* View all existing Claims that have been raised
* Raise a new Claim

To support this functionality, we currently have a Web API application which provides the following endpoints:
* /v1/policy – Search for an existing Policy
* /v1/claim/{claimnumber} – Search for an existing Claim
* /v1/claim – Create a new Claim