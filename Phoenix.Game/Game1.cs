#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using RogueSharp;

#endregion

namespace Phoenix.TestGame
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D _floor;
		Texture2D _wall;
		IMap _map;


		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = true;		
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			var creationStrategy = new RogueSharp.MapCreation.RandomRoomsMapCreationStrategy<Map>(50, 30, 100, 7, 3);
			_map = Map.Create (creationStrategy);
			base.Initialize ();
				
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here
			_floor = Content.Load<Texture2D>("floor.png");
			_wall = Content.Load<Texture2D> ("wall.png");
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			#endif
			// TODO: Add your update logic here			
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
		
			spriteBatch.Begin( SpriteSortMode.BackToFront, BlendState.AlphaBlend );

			int sizeOfSprites = 64;
			foreach ( Cell cell in _map.GetAllCells() )
			{
				if ( cell.IsWalkable )
				{
					var position = new Vector2( cell.X * sizeOfSprites, cell.Y * sizeOfSprites );
					spriteBatch.Draw( _floor, position, Color.White );
				}
				else
				{
					var position = new Vector2( cell.X * sizeOfSprites, cell.Y * sizeOfSprites );
					spriteBatch.Draw( _wall, position, Color.White );
				}
			}

			spriteBatch.End();
            
			base.Draw (gameTime);
		}
	}
}

