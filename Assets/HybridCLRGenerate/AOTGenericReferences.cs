using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"MessagePipe.VContainer.dll",
		"MessagePipe.dll",
		"ParadoxNotion.dll",
		"System.Core.dll",
		"UniTask.dll",
		"UnityEngine.CoreModule.dll",
		"VContainer.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<GameScripts.HotUpdate.Systems.Assets.Assets.<LoadAssetAsync>d__2<object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask.<>c<GameScripts.HotUpdate.Systems.Assets.Assets.<LoadSceneAsync>d__0>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<GameScripts.HotUpdate.Systems.Assets.Assets.<LoadAssetAsync>d__2<object>,object>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTask<GameScripts.HotUpdate.Systems.Assets.Assets.<LoadSceneAsync>d__0>
	// Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>
	// Cysharp.Threading.Tasks.CompilerServices.IStateMachineRunnerPromise<object>
	// Cysharp.Threading.Tasks.ITaskPoolNode<object>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.IUniTaskSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.IUniTaskSource<object>
	// Cysharp.Threading.Tasks.TaskPool<object>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.Awaiter<object>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.IsCanceledSource<object>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask.MemoizeSource<object>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// Cysharp.Threading.Tasks.UniTask<System.ValueTuple<byte,object>>
	// Cysharp.Threading.Tasks.UniTask<object>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<Cysharp.Threading.Tasks.AsyncUnit>
	// Cysharp.Threading.Tasks.UniTaskCompletionSourceCore<object>
	// MessagePipe.AnonymousMessageHandler<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>
	// MessagePipe.AnonymousMessageHandler<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>
	// MessagePipe.AnonymousMessageHandler<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>
	// MessagePipe.AnonymousMessageHandler<object>
	// MessagePipe.IPublisher<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>
	// MessagePipe.IPublisher<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>
	// MessagePipe.IPublisher<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>
	// MessagePipe.ISubscriber<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>
	// MessagePipe.ISubscriber<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>
	// MessagePipe.ISubscriber<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>
	// MessagePipe.ISubscriber<object>
	// NodeCanvas.Framework.Variable.<>c<byte>
	// NodeCanvas.Framework.Variable.<>c<object>
	// NodeCanvas.Framework.Variable.<>c__DisplayClass27_0<byte>
	// NodeCanvas.Framework.Variable.<>c__DisplayClass27_0<object>
	// NodeCanvas.Framework.Variable.<>c__DisplayClass27_1<byte>
	// NodeCanvas.Framework.Variable.<>c__DisplayClass27_1<object>
	// NodeCanvas.Framework.Variable.<>c__DisplayClass27_2<byte>
	// NodeCanvas.Framework.Variable.<>c__DisplayClass27_2<object>
	// NodeCanvas.Framework.Variable<byte>
	// NodeCanvas.Framework.Variable<object>
	// System.Action<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>
	// System.Action<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>
	// System.Action<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>
	// System.Action<byte>
	// System.Action<object>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.Comparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.Comparer<byte>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.EqualityComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.EqualityComparer<byte>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.ObjectComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.ObjectComparer<byte>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.Collections.Generic.ObjectEqualityComparer<System.ValueTuple<byte,object>>
	// System.Collections.Generic.ObjectEqualityComparer<byte>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.Stack.Enumerator<object>
	// System.Collections.Generic.Stack<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<object>
	// System.Func<byte>
	// System.Func<int>
	// System.Func<object,byte>
	// System.Func<object,object>
	// System.Func<object>
	// System.Linq.Enumerable.Iterator<object>
	// System.Linq.Enumerable.WhereEnumerableIterator<object>
	// System.Linq.Enumerable.WhereSelectArrayIterator<object,object>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<object,object>
	// System.Linq.Enumerable.WhereSelectListIterator<object,object>
	// System.Predicate<object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.CreateValueCallback<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.Enumerator<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable<object,object>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,System.ValueTuple<byte,object>>>
	// System.ValueTuple<byte,System.ValueTuple<byte,object>>
	// System.ValueTuple<byte,object>
	// }}

	public void RefMethods()
	{
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameScripts.HotUpdate.Systems.Assets.Assets.<LoadSceneAsync>d__0>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameScripts.HotUpdate.Systems.Assets.Assets.<LoadSceneAsync>d__0&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameScripts.HotUpdate.Systems.Assets.Assets.<LoadAssetAsync>d__2<object>>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameScripts.HotUpdate.Systems.Assets.Assets.<LoadAssetAsync>d__2<object>&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder.Start<GameScripts.HotUpdate.Systems.Assets.Assets.<LoadSceneAsync>d__0>(GameScripts.HotUpdate.Systems.Assets.Assets.<LoadSceneAsync>d__0&)
		// System.Void Cysharp.Threading.Tasks.CompilerServices.AsyncUniTaskMethodBuilder<object>.Start<GameScripts.HotUpdate.Systems.Assets.Assets.<LoadAssetAsync>d__2<object>>(GameScripts.HotUpdate.Systems.Assets.Assets.<LoadAssetAsync>d__2<object>&)
		// Cysharp.Threading.Tasks.UniTask.Awaiter Cysharp.Threading.Tasks.EnumeratorAsyncExtensions.GetAwaiter<object>(object)
		// System.Void Cysharp.Threading.Tasks.Internal.Error.ThrowArgumentNullException<object>(object,string)
		// VContainer.IContainerBuilder MessagePipe.ContainerBuilderExtensions.RegisterMessageBroker<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>(VContainer.IContainerBuilder,MessagePipe.MessagePipeOptions)
		// VContainer.IContainerBuilder MessagePipe.ContainerBuilderExtensions.RegisterMessageBroker<GameScripts.HotUpdate.UpdateAssets.TestMessage>(VContainer.IContainerBuilder,MessagePipe.MessagePipeOptions)
		// VContainer.IContainerBuilder MessagePipe.ContainerBuilderExtensions.RegisterMessageBroker<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>(VContainer.IContainerBuilder,MessagePipe.MessagePipeOptions)
		// VContainer.IContainerBuilder MessagePipe.ContainerBuilderExtensions.RegisterMessageBroker<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>(VContainer.IContainerBuilder,MessagePipe.MessagePipeOptions)
		// VContainer.IContainerBuilder MessagePipe.ContainerBuilderExtensions.RegisterMessageBroker<object>(VContainer.IContainerBuilder,MessagePipe.MessagePipeOptions)
		// System.IDisposable MessagePipe.SubscriberExtensions.Subscribe<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>(MessagePipe.ISubscriber<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>,System.Action<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>,MessagePipe.MessageHandlerFilter<GameScripts.HotUpdate.Game.MessageDefine.ChangeToBattleScene>[])
		// System.IDisposable MessagePipe.SubscriberExtensions.Subscribe<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>(MessagePipe.ISubscriber<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>,System.Action<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>,MessagePipe.MessageHandlerFilter<GameScripts.HotUpdate.UpdateAssets.UpdateProgressChange>[])
		// System.IDisposable MessagePipe.SubscriberExtensions.Subscribe<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>(MessagePipe.ISubscriber<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>,System.Action<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>,MessagePipe.MessageHandlerFilter<GameScripts.HotUpdate.UpdateAssets.UpdateResourceFailedInfo>[])
		// System.IDisposable MessagePipe.SubscriberExtensions.Subscribe<object>(MessagePipe.ISubscriber<object>,System.Action<object>,MessagePipe.MessageHandlerFilter<object>[])
		// NodeCanvas.Framework.Variable<byte> NodeCanvas.Framework.IBlackboardExtensions.GetVariable<byte>(NodeCanvas.Framework.IBlackboard,string)
		// NodeCanvas.Framework.Variable<object> NodeCanvas.Framework.IBlackboardExtensions.GetVariable<object>(NodeCanvas.Framework.IBlackboard,string)
		// object System.Activator.CreateInstance<object>()
		// object[] System.Array.Empty<object>()
		// bool System.Linq.Enumerable.Any<object>(System.Collections.Generic.IEnumerable<object>)
		// object System.Linq.Enumerable.FirstOrDefault<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<object>.Select<object>(System.Func<object,object>)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<Cysharp.Threading.Tasks.UniTask.Awaiter,GameScripts.Aot.GameLogic.UpdateResource.States.DownloadOver.<OnEnter>d__2>(Cysharp.Threading.Tasks.UniTask.Awaiter&,GameScripts.Aot.GameLogic.UpdateResource.States.DownloadOver.<OnEnter>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameScripts.Aot.GameLogic.UpdateResource.States.DownloadOver.<OnEnter>d__2>(GameScripts.Aot.GameLogic.UpdateResource.States.DownloadOver.<OnEnter>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<GameScripts.HotUpdate.UpdateAssets.FsmStates.UpdateDone.<OnEnter>d__0>(GameScripts.HotUpdate.UpdateAssets.FsmStates.UpdateDone.<OnEnter>d__0&)
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// object UnityEngine.Object.FindObjectOfType<object>()
		// VContainer.RegistrationBuilder VContainer.ContainerBuilderExtensions.Register<object,object>(VContainer.IContainerBuilder,VContainer.Lifetime)
		// VContainer.RegistrationBuilder VContainer.ContainerBuilderExtensions.Register<object>(VContainer.IContainerBuilder,VContainer.Lifetime)
		// VContainer.RegistrationBuilder VContainer.ContainerBuilderExtensions.RegisterInstance<object>(VContainer.IContainerBuilder,object)
		// object VContainer.IContainerBuilder.Register<object>(object)
		// VContainer.RegistrationBuilder VContainer.RegistrationBuilder.As<object>()
		// VContainer.RegistrationBuilder VContainer.Unity.ContainerBuilderUnityExtensions.RegisterEntryPoint<object>(VContainer.IContainerBuilder,VContainer.Lifetime)
		// object YooAsset.AssetOperationHandle.GetAssetObject<object>()
		// YooAsset.AssetOperationHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string)
		// YooAsset.AssetOperationHandle YooAsset.ResourcePackage.LoadAssetSync<object>(string)
		// YooAsset.AssetOperationHandle YooAsset.YooAssets.LoadAssetAsync<object>(string)
		// YooAsset.AssetOperationHandle YooAsset.YooAssets.LoadAssetSync<object>(string)
	}
}