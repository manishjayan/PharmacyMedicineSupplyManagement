# PharmacyMedicineSupplyManagement
FSE – Business Aligned Project 

## Project Overview 

A Pharmaceutical company wants to automate the logic of forming a schedule for their medical representatives to meet the targeted doctors to explain their medicines and its nature for prescription.  

## Scope
| Req. No. | Req. Name | Req. Description |
| --- | --- | --- |
| REQ_01 | Medicine stock module | This module is a Middleware Microservice that performs the following operations: Provides information on the pharma company medicine stock by the godown area  |
| REQ_02 | Medical representative schedule module | This module is a Middleware Microservice that performs following operations: * Creates a schedule to have meetings with doctors. * The list of doctors that this pharma company is targeting can be stored as a pre-defined information in this Microservice. * This module should interact with the medicine stock module to find the medicine stock to be explained to the targeted doctors. |
|REQ_03| Pharmacy  Supply module | This module is a Middleware Microservice that performs the following operations: * Gets the medicine count as demand as input from web portal. * Interacts with the Medicine supply microservice to find the final demand of medicine that can be supplied to its pharmacists.|
|REQ_04| Authorization service | This microservice is used with anonymous access to Generate JWT |
|REQ_05| Pharmacy medicine supply portal | A Web Portal that allows a member to Login and allows to do following operations: Login View a schedule for medical representative for doctors meet Provide in the data from medical reps with the medicine demand. Based on this input, the PharmacySupply microservice should provide the medicine count to be distributed to its pharmacists. This detail should be displayed on the UI. Medicine demand and supply to pharmacists should be saved in the database. |

## System Requirements
 
### Functional Requirements – Medicine stock Microservice 

<p align="center">
  <img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Req1.jpg">
</p>

### Functional Requirements – Medical representative schedule Microservice 
<p align="center">
  <img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Req2.jpg">
</p>

### Functional Requirements – Pharmacy medicine supply Microservice
<p align="center">
  <img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Req3.jpg">
</p>

### Functional Requirements – Authorization Microservice 
<p align="center">
  <img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Req4.jpg">
</p>

### Functional Requirements – Pharmacy Medicine Supply portal 
<p align="center">
  <img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Req5.jpg">
</p>
