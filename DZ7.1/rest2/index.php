<?php
$valid_passwords = array ("admin" => "admin");
$valid_users = array_keys($valid_passwords);

$user = $_SERVER['PHP_AUTH_USER'];
$pass = $_SERVER['PHP_AUTH_PW'];

$validated = (in_array($user, $valid_users)) && ($pass == $valid_passwords[$user]);

if (!$validated) {
  header('WWW-Authenticate: Basic realm="My Realm"');
  header('HTTP/1.0 401 Unauthorized');
  die ("Not authorized");
}

// Connect to database
	Class dbObj{
	
	var $servername = "localhost";
	var $username = "root";
	var $password = "";
	var $dbname = "movies";
	var $conn;
	function getConnstring() {
		$con = mysqli_connect($this->servername, $this->username, $this->password, $this->dbname) or die("Connection failed: " . mysqli_connect_error());
 
		
		if (mysqli_connect_errno()) {
			printf("Connect failed: %s\n", mysqli_connect_error());
			exit();
		} else {
			$this->conn = $con;
		}
		return $this->conn;
	}
}

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
	
	$db = new dbObj();
	$connection =  $db->getConnstring();
 
	$request_method=$_SERVER["REQUEST_METHOD"];
	switch($request_method)
	{
		case 'GET':
			// Retrive Products
			//print_r($_GET);
			if(!empty($_GET["movie_id"]))
			{
				$id=intval($_GET["movie_id"]);
				get_movies($id);
			}
			else
			{
				get_movies();
			}
			break;
			
			case 'POST':
			// Insert Product
			insert_movie();
			break;	
			
			case 'PUT':
			// Update Product		
			if (isset($_GET["movie_id"])){
				$id=intval($_GET["movie_id"]);
				update_movie($movie_id);				
			}
			else{
				header('Content-Type: application/json');
				echo json_encode("Error while calling method and parametars");
				
			}				
			
			break;				
			case 'DELETE':
			// Delete Product
			$id=intval($_GET["movie_id"]);
			delete_movie($movie_id);
			break;
			
		default:
			// Invalid Request Method
			header("HTTP/1.0 405 Method Not Allowed");
			break;
	}
?>
