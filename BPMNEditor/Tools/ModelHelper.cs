using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.Models.Elements;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Tools
{
    public static class ModelHelper
    {
        public static void AddModelConnection(ElementsConnectionViewModel connection)
        {
            try
            {
                PoolElementViewModel startElementViewModel = connection.From as PoolElementViewModel;
                PoolElement pool = startElementViewModel.Pool.BaseElement as PoolElement;
                pool.Connections.Add(connection.Model);
            }
            catch (NullReferenceException exception)
            {
                throw new ArgumentException("Error while creating connection. Model not found", exception);
            }

        }

        public static void RemoveConnectionModel(ElementsConnectionViewModel connection)
        {
            try
            {
                PoolElementViewModel startElementViewModel = connection.From as PoolElementViewModel;
                PoolElement pool = startElementViewModel.Pool.BaseElement as PoolElement;
                pool.Connections.Remove(connection.Model);
            }
            catch (NullReferenceException exception)
            {
                throw new ArgumentException("Error while creating connection. Model not found", exception);
            }
        }
    }
}
