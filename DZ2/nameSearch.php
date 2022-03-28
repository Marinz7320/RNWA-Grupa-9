<!DOCTYPE html>
<html>
<head>
<style>
table {
  border-collapse: collapse;
  border:solid 2px gray;
  width: 100%;
}

th, td {
  text-align: left;
  padding: 8px;
}
table button {
  height: 32px;
  width: 40px;
  border: none;
  padding-right: 11px;
  border-radius: 0 5px 5px 0;
  background-color: #f2f2f2;
  outline: none;
  cursor: pointer;
  color:purple;
}
tr:nth-child(even) {background-color: #f2f2f2;}
</style>
</head>
<body>

<?php
$s = $_REQUEST["s"];
$hint = "";

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
?>
</body>
</html>