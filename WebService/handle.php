<?php
include("includes/db.php");
if (isset($_GET['action']))
	if ($_GET['action'] == 'auth')	{
		if(isset($_GET['login']) && isset($_GET['prefix']) && isset($_GET['hash'])) {
			header("Content-type: text/txt; charset=UTF-8");
			$res = mysqli_query($connection,"SELECT token FROM `Users` WHERE login = '{$_GET['login']}' AND prefix= '{$_GET['prefix']}' AND hash = '{$_GET['hash']}'");
			if ($res)
			{
				if (mysqli_num_rows($res) > 0)
				{
					echo mysqli_fetch_assoc($res)['token'];
				}
				else
					{ echo "auth_not_succ"; }
			}
			else
				echo "auth_error";
		}
		else
		{
			echo "0";
		}
	}
	elseif ($_GET['action'] == 'reg')	{
		if(isset($_GET['login']) && isset($_GET['prefix']) && isset($_GET['hash'])) {
			header("Content-type: text/txt; charset=UTF-8");
			$res = mysqli_query($connection,"SELECT * FROM `Users` WHERE login = '{$_GET['login']}'");
			if ($res)
			{
				if (mysqli_num_rows($res) == 0)
				{
					$res2 = mysqli_query($connection, "SELECT REPLACE(CAST(UUID() as char character set utf8), '-', '_')");
					$res3 = mysqli_fetch_array($res2)[0];
					$res1 = mysqli_query($connection,"INSERT INTO `Users`(`login`, `prefix`, `hash`, `token`) VALUES ('{$_GET['login']}','{$_GET['prefix']}','{$_GET['hash']}', '{$res3}')");
					echo $res3;
				}
				else
					{ echo "login_exists"; }
			}
			else echo "0";
		}
		else
		{
			echo "0";
		}
	}
	elseif ($_GET['action'] == 'getprefix')	{
		if(isset($_GET['login'])) {
			header("Content-type: text/txt; charset=UTF-8");
			$res = mysqli_query($connection,"SELECT * FROM `Users` WHERE login = '{$_GET['login']}'");
			if ($res)
			{
				if (mysqli_num_rows($res) > 0)
				{
					echo mysqli_fetch_assoc($res)['prefix'];
				}
				else
					{ echo "incorrect_login"; }
			}
			else echo "0";
		}
		else
		{
			echo "0";
		}
	}
	else
		echo "0";
else
	echo "0";
?>