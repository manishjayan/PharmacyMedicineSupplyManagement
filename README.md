# Pharmacy Medicine Supply Management
                                 FSE – Business Aligned Project 

## Project Overview 

A Pharmaceutical company wants to automate the logic of forming a schedule for their medical representatives to meet the targeted doctors to explain their medicines and its nature for prescription.  

## Scope
<table>
	<tr>
		<th>Req. No.</th>
		<th>Req. Name</th>
		<th>Req. Description</th>
	</tr>
	<tr>
		<td>REQ_01</td>
		<td>Medicine stock module</td>
		<td>
			This module is a Middleware Microservice that performs the following operations: 
			<ul><li>
				Provides information on the pharma company medicine stock by the godown area
			</li></ul>
		</td>
	</tr>
	<tr>
		<td>REQ_02</td>
		<td>Medical representative schedule module</td>
		<td>
			This module is a Middleware Microservice that performs following operations:
			<ul>
				<li>Creates a schedule to have meetings with doctors. </li>
				<li>The list of doctors that this pharma company is targeting can be stored as a pre-defined information in this Microservice.</li>
				<li>This module should interact with the medicine stock module to find the medicine stock to be explained to the targeted doctors.</li>
			</ul>
		</td>
	</tr>
	<tr>
		<td>REQ_03</td>
		<td>Pharmacy  Supply module</td>
		<td>
			This module is a Middleware Microservice that performs the following operations: 
			<ul>
				<li>Gets the medicine count as demand as input from web portal.</li>
				<li>Interacts with the Medicine supply microservice to find the final demand of medicine that can be supplied to its pharmacists.</li>
			</ul>
		</td>
	</tr>
	<tr>
		<td>REQ_04</td>
		<td>Authorization service</td>
		<td>
			This microservice is used with anonymous access to Generate JWT
		</td>
	</tr>
	<tr>
		<td>REQ_05</td>
		<td>Pharmacy medicine supply portal</td>
		<td>
			A Web Portal that allows a member to Login and allows to do following operations:
			<ul>
				<li>Login</li>
				<li>View a schedule for medical representative for doctors meet Provide in the data from medical reps with the medicine demand.</li>
				<li>Based on this input, the PharmacySupply microservice should provide the medicine count to be distributed to its pharmacists.This detail should be displayed on the UI.</li>
				<li>Medicine demand and supply to pharmacists should be saved in the database.</li>
			</ul>
		</td>
	</tr>
</table>

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
