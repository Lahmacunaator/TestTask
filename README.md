# Introduction
* Can return the Map as a json.
* Can return the total water surface area in the map as a json.
* Can return the total lake surface area in the map as a json.
* Gets either a file input or a Post method.

# Overview
* Can read Map data from the file ***Input.asc*** located in ***Resources*** folder.
* Can take the Map data with a post request.
* ***Symbols:***
	<table>
	<tr>
	<th>Symbol</th>
	<th>Reference</th>
	</tr>
	<tr>
		<td>#</td>
		<td>Land Square</td>
	</tr>
	<tr>
		<td>O</td>
		<td>Water Square</td>
	</tr>
	<tr>
		<td>Other symbols</td>
		<td>Unidentified Square</td>
	</tr>
	</table>
 
# Requirements
1. The input map needs to be rectangular, which means each **Row** having the same length.
2. Rows can't contain whitespaces.
3. ***For Post methods:***
   * While building the **request url** in **Postman**, "#" and *Line Space* characters can't be used.
   * Following needs to be used instead:
   <table>
	<tr>
	<th>Symbol</th>
	<th>Url String</th>
	</tr>
	<tr>
		<td>#</td>
		<td>%23</td>
	</tr>
	<tr>
		<td>Line Space</td>
		<td>%20</td>
	</tr>
	<tr>
		<td>O</td>
		<td>O</td>
	</tr>
	</table>

# Status Codes
<table>
	<tr>
	<th>Status Code</th>
	<th>Result</th>
	</tr>
	<tr>
		<td>200</td>
		<td>Success</td>
	</tr>
	<tr>
		<td>400</td>
		<td>Item is null</td>
	</tr>
		<tr>
		<td>404</td>
		<td>Not Found - Wrong Type Of Input (Post Methods)</td>
	</tr>
</table>

PS. Swagger UI is at the index.
