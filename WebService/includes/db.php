<?php
	$connection = mysqli_connect('127.0.0.1','root','','finances');
		if ($connection == false)
		{
			echo "Не получилось чот;)))) <br>";
			echo mysqli_connect_error();
			exit();
		}
 ?>