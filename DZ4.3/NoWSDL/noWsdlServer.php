<?php 
$conn = mysqli_connect("localhost", "root", "", "birt") or die("Connection failed: " . mysqli_connect_error());
if (mysqli_connect_errno()) {
    printf("Connect failed: %s\n", mysqli_connect_error());
    exit();
}

if(isset($_GET['movie_id'])) {	
	$officecode = $_GET['movie_id']; 
	$sql_query = "select* from movie_id where officeCode = $movie_id";
	$response = mysqli_query($conn, $sql_query) or die("database error:". mysqli_error($conn));	
	$rows = array();
	while($r = mysqli_fetch_assoc($response)) {
    $rows[] = $r;
	}
	print json_encode($rows);	
}
?>	
