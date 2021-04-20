# Pharmacy Medicine Supply Management
FSE – Business Aligned Project System 

## Project Overview 

A Pharmaceutical company wants to automate the logic of forming a schedule for their medical representatives to meet the targeted doctors to explain their medicines and its nature for prescription. 

## Sofware Requirement

<ol>
	<li>Postman</li>
</ol>

## Deployed Microservice API Urls
<br>
<table>
	<tr>
		<th>URL</th>
		<th>REQUEST METHOD</th>
		<th>RESPONSE</th>
		<th>MICROSERVICE</th>
	</tr>
	<tr>
		<td>
			http://40.89.248.91/api/Authentication?Username=test&Password=Pass
		</td>
		<td>GET</td>
		<td>Generated token</td>
		<td>Authorization</td>
	</tr>
	<tr>
		<td>
			http://52.224.73.213/api/MedicineStockInformation
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


## How to Use all the apis Deployed

<ol>
	<li>Getting Medicine Stock List </li><br>
	<p align="center">
  		<img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Images/image1.png">
	</p>
	<li>Generating Token </li><br>
	<p align="center">
  		<img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Images/image2.png">
	</p>
	<li>Using Generated Token to book a meeting schedule using Medical Representative Schedule API </li><br>
	<p align="center">
  		<img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Images/image3.png">
	</p>
	<li>Using Generated Token to Add demand Medicine to Pharmacy Supply Microservice for the Pharmacy medicine distribution list.</li><br>
	<p align="center">
  		<img src="https://github.com/manishjayan/PharmacyMedicineSupplyManagement/blob/master/ProjectRequirementDocs/Images/image4.png">
	</p>
</ol>
