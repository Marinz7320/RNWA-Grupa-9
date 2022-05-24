<!DOCTYPE html>
<html>
<head>
<style>
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

function get_movies($id=0)
	{
	global $connection;
	$query="SELECT * FROM movie";
	if($id != 0)
	{
		$query.=" WHERE movie_id=".$id." LIMIT 100";
	}
	$response=array();
	$result=mysqli_query($connection, $query);
	while($row=mysqli_fetch_array($result,MYSQLI_BOTH))
	{
		$response[]=$row;
	}
	header('Content-Type: application/json');
	echo json_encode($response);
	$response = $connection->query($sql)or die("Querry failed");
	if(mysqli_num_rows($response) > 0)
	{
	echo "<table>
	<tr>
	<th>Movie Name</th>
	<th>Budget</th>
	</tr>";
	while ($row=mysqli_fetch_row($response)){
		echo "<tr>";
		echo "<td>" .$row[1] . "</td>";
	echo "<td>" . $row[2] . "</td>";
	echo "<td><button>Insert a movie</button></td>";
	echo "<td><button>Details</button></td>";
	echo "<td><button>Update</button></td>";
	echo "<td><button>Delete</button></td>";
		echo "</tr>";
	}
	echo "</table>";
	}
	}


function insert_employee()
	{
		global $connection;

		$data = json_decode(file_get_contents('php://input'), true);
		$movie_id	=$data["movie_id"];
		$budget		=$data["budget"];
		$title = 	$data["title"];
		$homepage	=$data["homepage"];
		$overview	=$data["overview"];
		$popularity	=$data["popularity"];
		$release_date =$data["release_date"];
		$revenue	=$data["revenue"];
		$movie_status =$data["movie_status"];
		$tagline = $data["tagline"];
		$vote_average = $data["vote_average"];
		$vote_count = $data["vote_count"];
		
		echo $query="INSERT INTO movie VALUES (NULL, '".$movie_id."','".$title."','".$budget."','".$homepage."','".$overview."','".$popularity."','".$release_date."','".$revenue."','".$runtime."','".$movie_status."','".$tagline."','".$vote_average."','".$vote_count."',NOW())";
		if(mysqli_query($connection, $query))
		{
			$broj_redaka = mysqli_affected_rows($connection);
			$response=array(
				'status' => 1,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Film uspješno insertan.'
			);
		}
		else
		{
			$broj_redaka = mysqli_affected_rows($connection);
			$response=array(
				'status' => 0,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Movie Insertion failed.'
			);
		}
		header('Content-Type: application/json');
		echo json_encode($response);
	}
function update_movie($id)
	{
		global $connection;
		$post_vars = json_decode(file_get_contents("php://input"),true);
		$movie_id	=$data["movie_id"];
		$title = 	$data["title"];
		$budget		=$data["budget"];
		$homepage	=$data["homepage"];
		$overview	=$data["overview"];
		$popularity	=$data["popularity"];
		$release_date =$data["release_date"];
		$revenue	=$data["revenue"];
		$movie_status =$data["movie_status"];
		$tagline = $data["tagline"];
		$vote_average = $data["vote_average"];
		$vote_count = $data["vote_count"];
		
		$query="UPDATE movie SET title='".$title."', budget='".$budget."',homepage='".$homepage."',popularity = '".$popularity."' WHERE movie_id=".$id;
		
		$result=mysqli_query($connection, $query);
		$broj_redaka = mysqli_affected_rows($connection);;
		
		if($result)
		{
			$response=array(
				'status' => 1,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Movie updated succesfully.'
			);
		}
		else
		{
			$response=array(
				'status' => 0,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Movie Updation Failed.'
			);
		}
		header('Content-Type: application/json');
		echo json_encode($response);
	}

function delete_movie($id)
	{
	global $connection;
	$query="DELETE FROM movie WHERE movie_id=".$id;
	if($result = mysqli_query($connection, $query))
	{
		$response=array(
			'status' => 1,
			'status_message' =>'Movie Deleted Successfully.'
		);
	}
	else
	{
		$response=array(
			'status' => 0,
			'status_message' =>'Movie Deletion Failed.'
		);
	}
	header('Content-Type: application/json');
	echo json_encode($response);
	}


?>
