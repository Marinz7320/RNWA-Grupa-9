<!DOCTYPE html>
<html>
<head>
<style>
/*Citav DZ2.2 staviti u /xaamp/htdocs folder da se provjeri funkcionalnost. Baza podataka se nalazi na phpMyAdminu*/
table {
  border-collapse: collapse;
  border:solid 2px gray;
  width: 100%;
  color : purple;
}

th, td {
  text-align: left;
  padding: 8px;
}
table button {
  height: 32px;
  padding-right: 11px;
  border-radius: 0 5px 5px 0;
  outline: none;
  cursor: pointer;
  color:purple;
  background-color :#f2f2f2;
}
tr:nth-child(even) {background-color: #f2f2f2;}
</style>
</head>
<body>

<?php
if(isset($_POST['s'])){
  $s = $_POST['s']; 
}else{
  $s = "Name not set in GET Method";
}

// Konekcija baze
$connection = mysqli_connect('localhost:3307','root','','movies');

if (!$connection) {
    error_log("Failed to connect to MySQL: " . mysqli_error($connection));
    die('Internal server error');
}

// Odabir baze
$db_select = mysqli_select_db($connection, 'movies');
if (!$db_select) {
    error_log("Database selection failed: " . mysqli_error($connection));
    die('Internal server error');
}else
{
$sql="SELECT * FROM `movie` WHERE `title` LIKE  '%$s%' ";

$response = $connection->query($sql)or die("Querry failed");
if(mysqli_num_rows($response) > 0)
{
echo "<table>
<tr>
<th>Movie Name</th>
<th>Budget</th>
</tr>";
while ($myrow=mysqli_fetch_row($response)){
			echo "<tr>";
			  echo "<td>" . $myrow[1] . "</td>";
        echo "<td>" . $myrow[2] . "</td>";
        echo "<td><button>Details</button></td>";
        echo "<td><button>Update</button></td>";
        echo "<td><button>Delete</button></td>";
			  echo "</tr>";
		}

echo "</table>";
}
}
?>
</body>
</html>