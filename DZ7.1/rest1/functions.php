<?php

function get_movies($movie_id=0)
	{
	global $connection;
	$query="SELECT * FROM movie";
	if($id != 0)
	{
		$query.=" WHERE movie_id=".$movie_id." LIMIT 100";
	}
	$response=array();
	$result=mysqli_query($connection, $query);
	while($row=mysqli_fetch_array($result,MYSQLI_BOTH))
	{
		$response[]=$row;
	}
	header('Content-Type: application/json');
	echo json_encode($response);
	}

function insert_movie()
	{
		global $connection;

		$data = json_decode(file_get_contents('php://input'), true);
		$movie_id		=$data["movie_id"];
		$title			=$data["title"];
		$budget			=$data["budget"];
		$homepage		=$data["homepage"];
		$overview		=$data["overview"];
		$popularity		=$data["popularity"];
		$release_date	=$data["release_date"];
		$revenue		=$data["revenue"];
		$runtime        =$data["runtime"];
		$movie_status   =$data["movie_status"];
		$tagline        =$data["tagline"];
		$vote_average   =$data["vote_average"];
		
		echo $query="INSERT INTO movie VALUES (NULL, '".$movie_id."','".$title."','".$budget."','".$homepage."','".$overview."','".$popularity."','".$release_date."','".$revenue."','".$runtime."','".$movie_status."','".$tagline."','".$vote_average."','".$vote_average."',NOW())";
		if(mysqli_query($connection, $query))
		{
			$broj_redaka = mysqli_affected_rows($connection);
			$response=array(
				'status' => 1,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Employee Added Successfully.'
			);
		}
		else
		{
			$broj_redaka = mysqli_affected_rows($connection);
			$response=array(
				'status' => 0,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Movie Addition Failed.'
			);
		}
		header('Content-Type: application/json');
		echo json_encode($response);
	}
function update_movie($movie_id)
	{
		global $connection;
		$post_vars = json_decode(file_get_contents("php://input"),true);
		$title			=$data["title"];
		$budget			=$data["budget"];
		$homepage		=$data["homepage"];
		$overview		=$data["overview"];
		$popularity		=$data["popularity"];
		$release_date	=$data["release_date"];
		$revenue		=$data["revenue"];
		$runtime        =$data["runtime"];
		$movie_status   =$data["movie_status"];
		$tagline        =$data["tagline"];
		$vote_average   =$data["vote_average"];
		
		$query="UPDATE movie SET title='".$title."', budget='".$budget."', homepage='".$homepage."', overview='".$overview."', popularity='".$popularity."',  release_date='".$release_date."', revenue='".$revenue."',runtime='".$runtime."',movie_status='".$movie_status."',tagline='".$tagline."', vote_average='".$vote_average."', vote_count='".$vote_count."'WHERE movie_id=".$movie_id;
		
		$result=mysqli_query($connection, $query);
		$broj_redaka = mysqli_affected_rows($connection);;
		
		if($result)
		{
			$response=array(
				'status' => 1,
				'query' => $query,
				'broj_redaka' => $broj_redaka,
				'status_message' =>'Movie Updated Successfully.'
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

function delete_movie($movie_id)
	{
	global $connection;
	$query="DELETE FROM movie WHERE movie_id=".$movie_id;
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
