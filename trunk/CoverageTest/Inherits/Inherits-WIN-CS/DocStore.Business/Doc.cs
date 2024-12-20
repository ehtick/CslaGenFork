//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    Doc
// ObjectType:  Doc
// CSLAType:    EditableRoot

using System;
using Csla;
using DocStore.Business.Util;

namespace DocStore.Business
{
    public partial class Doc
    {

        #region OnDeserialized actions

        /// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        /// <param name="context">Serialization context object.</param>
        protected override void OnDeserialized(System.Runtime.Serialization.StreamingContext context)
        {
            base.OnDeserialized(context);
            Saved += OnDocSaved;
            // add your custom OnDeserialized actions here.
        }

        #endregion

        #region Custom Business Rules and Property Authorization

        //partial void AddBusinessRulesExtend()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Custom Object Authorization

        //static partial void AddObjectAuthorizationRulesExtend()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region ChildChanged Event Handler

        /*/// <summary>
        /// Raises the ChildChanged event, indicating that a child object has been changed.
        /// </summary>
        /// <param name="e">ChildChangedEventArgs object.</param>
        protected override void OnChildChanged(Csla.Core.ChildChangedEventArgs e)
        {
            base.OnChildChanged(e);

            // uncomment the lines for child with properties relevant to business rules
            //PropertyHasChanged(EditContentProperty);
            //PropertyHasChanged(FoldersProperty);
            //PropertyHasChanged(CirculationsProperty);
            //PropertyHasChanged(ViewContentProperty);
            //PropertyHasChanged(ContentsProperty);
            // uncomment if there is an object level business rule (introduced in Csla 4.2.0)
            //CheckObjectRules();
        }*/

        #endregion

        #region Implementation of DataPortal Hooks

        //partial void OnCreate(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnFetchPre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnFetchPost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnFetchRead(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnUpdatePre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnUpdatePost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnInsertPre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnInsertPost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}
