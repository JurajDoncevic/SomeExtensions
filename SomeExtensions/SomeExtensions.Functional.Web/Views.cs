using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Web
{
    public static class Views
    {
        public static IActionResult ToView<TInput>(this TInput target, Controller ctrl, Func<ViewDataDictionary, ViewDataDictionary> setViewData)
        {
            ctrl.ViewData = setViewData(ctrl.ViewData);
            return ctrl.View();
        }

        public static IActionResult ToView<TInput>(this TInput target, Controller ctrl) =>
            ctrl.View(target);

        public static IActionResult ToView(Controller ctrl) =>
            ctrl.View();

        public static IActionResult ToView<TInput>(Controller ctrl, Func<ViewDataDictionary, ViewDataDictionary> setViewData)
        {
            ctrl.ViewData = setViewData(ctrl.ViewData);
            return ctrl.View();
        }


        public static IActionResult ToAction<TInput>(this TInput target, Controller ctrl, string actionName) =>
            ctrl.RedirectToAction(actionName);

        public static IActionResult ToAction<TInput>(this TInput target, Controller ctrl, string actionName, Func<ITempDataDictionary, ITempDataDictionary> setTempData)
        {
            ctrl.TempData = setTempData(ctrl.TempData);
            return ctrl.RedirectToAction(actionName);
        }
            
        public static IActionResult ToErrorCode<TInput>(this TInput target, Controller ctrl, int errorCode) =>
            ctrl.StatusCode(errorCode);

        public static IActionResult ToErrorCode(Controller ctrl, int errorCode) =>
            ctrl.StatusCode(errorCode);

        public static IActionResult ToAction(Controller ctrl, string actionName) =>
            ctrl.RedirectToAction(actionName);

        public static IActionResult ToAction<TInput>(Controller ctrl, string actionName, Func<ITempDataDictionary, ITempDataDictionary> setTempData)
        {
            ctrl.TempData = setTempData(ctrl.TempData);
            return ctrl.RedirectToAction(actionName);
        }
    }
}
