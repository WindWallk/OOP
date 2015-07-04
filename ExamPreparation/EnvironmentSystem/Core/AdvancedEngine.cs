using System;
using EnvironmentSystem.Interfaces;
using EnvironmentSystem.Models.Objects;

namespace EnvironmentSystem.Core
{
    public class AdvancedEngine : Engine
    {
        private IController controller;
        private bool IsPaused = false;

        public AdvancedEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, ICollisionHandler collisionHandler, IRenderer renderer, IController controller)
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
            this.AttachControllerEvents();
        }

        private void AttachControllerEvents()
        {
            this.controller.Pause += controller_Pause;
        }

        private void controller_Pause(object sender, EventArgs e)
        {
            this.IsPaused = !this.IsPaused;
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object cannot be null!");
            }
            base.Insert(obj);
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();

            if (!IsPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
        }
    }
}
