<?php
// Connect to database
	include("../connection.php");
	include("../functions.php");
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
