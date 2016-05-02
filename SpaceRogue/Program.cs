using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRogue
{
	using RLNET;

	static class Program
	{
		// Tileset bitmap and size in pixels
		static string bitmapFilename = "terminal8x8.png";
		static int tileWidth = 8;
		static int tileHeight = 8;

		// Game Window and title
		static RLRootConsole rootConsole;
		static string rootConsoleTitle = "RLNet RogueSharp Test";
		static int screenWidth = 150;
		static int screenHeight = 84;
		
		// Map console
		static RLConsole mapConsole;
		static int mapWidth = 110;
		static int mapHeight = 60;

		// Message console
		static RLConsole messageConsole;
		static int messageWidth = 110;
		static int messageHeight = 24;

		// Info console
		static RLConsole infoConsole;
		static int infoWidth = 40;
		static int infoHeight = 42;

		// Action console
		static RLConsole actionConsole;
		static int actionWidth = 40;
		static int actionHeight = 42;

		static void Main()
		{
			// Consoles initialization
			rootConsole = new RLRootConsole(bitmapFilename, screenWidth, screenHeight, tileWidth, tileHeight, 1f, rootConsoleTitle);
			mapConsole = new RLConsole(mapWidth, mapHeight);
			messageConsole = new RLConsole(messageWidth, messageHeight);
			infoConsole = new RLConsole(infoWidth, infoHeight);
			actionConsole = new RLConsole(actionWidth, actionHeight);

			// Events binding
			rootConsole.Update += OnRootConsoleUpdate;
			rootConsole.Render += OnRootConsoleRender;

			// Punch it, Chewie!
			rootConsole.Run();
		}

		static void DrawMapConsole()
		{
			mapConsole.SetBackColor(0, 0, mapWidth, mapHeight, RLColor.Black);
			mapConsole.Print(1, 1, "Map", RLColor.White);
		}

		static void DrawMessageConsole()
		{
			messageConsole.SetBackColor(0, 0, messageWidth, messageHeight, RLColor.Gray);
			messageConsole.Print(1, 1, "Message", RLColor.White);
		}

		static void DrawInfoConsole()
		{
			infoConsole.SetBackColor(0, 0, infoWidth, infoHeight, RLColor.Blue);
			infoConsole.Print(1, 1, "Info", RLColor.White);
		}

		static void DrawActionConsole()
		{
			actionConsole.SetBackColor(0, 0, actionWidth, actionHeight, RLColor.Green);
			actionConsole.Print(1, 1, "Action", RLColor.White);
		}

		static void DrawConsoles()
		{
			DrawMapConsole();
			DrawMessageConsole();
			DrawInfoConsole();
			DrawActionConsole();
		}

		static void BlitConsoles()
		{
			// Blit sub consoles to root
			RLConsole.Blit(mapConsole, 0, 0, mapWidth, mapHeight, rootConsole, 0, 0);
			RLConsole.Blit(messageConsole, 0, 0, messageWidth, messageHeight, rootConsole, 0, mapHeight);
			RLConsole.Blit(infoConsole, 0, 0, infoWidth, infoHeight, rootConsole, mapWidth, 0);
			RLConsole.Blit(actionConsole, 0, 0, actionWidth, actionHeight, rootConsole, mapWidth, infoHeight);
		}

		static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
		{
			
		}

		static void OnRootConsoleRender(object sender, UpdateEventArgs e)
		{
			rootConsole.Clear();
			DrawConsoles();
			BlitConsoles();
			rootConsole.Draw();
		}
	}
}
