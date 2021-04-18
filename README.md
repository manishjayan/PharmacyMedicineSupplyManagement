# Pharmacy Medicine Supply Management
FSE – Business Aligned Project System 

## Project Overview 

A Pharmaceutical company wants to automate the logic of forming a schedule for their medical representatives to meet the targeted doctors to explain their medicines and its nature for prescription. 

## Deployed Microservice API Urls
<table>
	<tr>
		<th>URL</th>
		<th>REQUEST METHOD</th>
		<th>RESPONSE</th>
		<th>MICROSERVICE</th>
	</tr>
	<tr>
		<td>
			http://40.88.221.195/api/Authentication?Username=test&Password=Pass
		</td>
		<td>GET</td>
		<td>Generated token</td>
		<td>Authorization</td>
	</tr>
	<tr>
		<td>
			http://40.71.234.220/api/MedicineStockInformation
		</td>
		<td>GET</td>
		<td>Medicine stock list</td>
		<td>Medicine Stock</td>
	</tr>
	<tr>
		<td>
			http://52.158.217.233/api/RepSchedule?startDate=4%2F18%2F2021
		</td>
		<td>GET</td>
		<td>List of Representative Schedule</td>
		<td>Medical Representative Schedule</td>
	</tr>
	<tr>
		<td>
			http://20.84.216.142/api/PharmacySupply
		</td>
		<td>POST</td>
		<td>Fetch medicine distribution list</td>
		<td>PharmacyMedicine Supply</td>
	</tr>
</table>

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
