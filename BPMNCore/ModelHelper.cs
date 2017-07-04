using System;
using BPMNCore.Elements;
using BPMNCore.ViewModels;

namespace BPMNCore
{
    public static class ModelHelper
    {
        public static void AddModelConnection(ElementsConnectionViewModel connection)
        {
            try
            {
                PoolElementViewModel startElementViewModel = connection.From as PoolElementViewModel;
                PoolViewModel poolElementViewModel = startElementViewModel.Pool;
                PoolElement pool = null;
                if (poolElementViewModel != null)
                {
                    pool = startElementViewModel.Pool.BaseElement as PoolElement;
                }
                else
                {
                    pool = startElementViewModel.Document.Document.MainPoolElement;
                }
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
                PoolViewModel poolElementViewModel = startElementViewModel.Pool;
                PoolElement pool = null;
                if (poolElementViewModel != null)
                {
                    pool = startElementViewModel.Pool.BaseElement as PoolElement;
                }
                else
                {
                    pool = startElementViewModel.Document.Document.MainPoolElement;
                }
                pool.Connections.Remove(connection.Model);
            }
            catch (NullReferenceException exception)
            {
                throw new ArgumentException("Error while creating connection. Model not found", exception);
            }
        }
    }
}
