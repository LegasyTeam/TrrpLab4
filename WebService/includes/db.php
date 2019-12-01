<?php
	$connection = mysqli_connect('remotemysql.com:3306','11ayOeNb9v','0mI6sAI8oz','11ayOeNb9v');
		if ($connection == false)
		{
			echo "Не получилось чот;)))) <br>";
			echo mysqli_connect_error();
			exit();
		}
 ?>