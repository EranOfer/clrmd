﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Diagnostics.Runtime.Private
{
    public enum CodeHeapType
    {
        Loader,
        Host,
        Unknown
    }

    public interface ICodeHeap
    {
        CodeHeapType Type { get; }
        ulong Address { get; }
    }

    public interface IThreadPoolData
    {
        int TotalThreads { get; }
        int RunningThreads { get; }
        int IdleThreads { get; }
        int MinThreads { get; }
        int MaxThreads { get; }
        ulong FirstWorkRequest { get; }
        ulong QueueUserWorkItemCallbackFPtr { get; }
        ulong AsyncCallbackCompletionFPtr { get; }
        ulong AsyncTimerCallbackCompletionFPtr { get; }
        int MinCP { get; }
        int MaxCP { get; }
        int CPU { get; }
        int NumFreeCP { get; }
        int MaxFreeCP { get; }
    }

    public interface IAssemblyData
    {
        ulong Address { get; }
        ulong ParentDomain { get; }
        ulong AppDomain { get; }
        bool IsDynamic { get; }
        bool IsDomainNeutral { get; }
        int ModuleCount { get; }
    }

    public interface IAppDomainData
    {
        int Id { get; }
        ulong Address { get; }
        ulong LowFrequencyHeap { get; }
        ulong HighFrequencyHeap { get; }
        ulong StubHeap { get; }
        int AssemblyCount { get; }
    }

    public interface IThreadStoreData
    {
        ulong Finalizer { get; }
        ulong FirstThread { get; }
        int Count { get; }
    }

    public interface IThreadData
    {
        ulong Next { get; }
        ulong AllocPtr { get; }
        ulong AllocLimit { get; }
        uint OSThreadID { get; }
        uint ManagedThreadID { get; }
        ulong Teb { get; }
        ulong AppDomain { get; }
        uint LockCount { get; }
        int State { get; }
        ulong ExceptionPtr { get; }
        bool Preemptive { get; }
    }

    public interface ISegmentData
    {
        ulong Address { get; }
        ulong Next { get; }
        ulong Start { get; }
        ulong End { get; }
        ulong Committed { get; }
        ulong Reserved { get; }
    }

    public interface IHeapDetails
    {
        ulong FirstHeapSegment { get; }
        ulong FirstLargeHeapSegment { get; }
        ulong EphemeralSegment { get; }
        ulong EphemeralEnd { get; }
        ulong EphemeralAllocContextPtr { get; }
        ulong EphemeralAllocContextLimit { get; }

        ulong Gen0Start { get; }
        ulong Gen0Stop { get; }
        ulong Gen1Start { get; }
        ulong Gen1Stop { get; }
        ulong Gen2Start { get; }
        ulong Gen2Stop { get; }

        ulong FQAllObjectsStart { get; }
        ulong FQAllObjectsStop { get; }
        ulong FQRootsStart { get; }
        ulong FQRootsEnd { get; }
    }

    public interface IGCInfo
    {
        bool ServerMode { get; }
        int HeapCount { get; }
        int MaxGeneration { get; }
        bool GCStructuresValid { get; }
    }

    public interface IMethodTableData
    {
        bool Shared { get; }
        bool Free { get; }
        bool ContainsPointers { get; }
        uint BaseSize { get; }
        uint ComponentSize { get; }
        ulong EEClass { get; }
        ulong Parent { get; }
        uint NumMethods { get; }
        ulong ElementTypeHandle { get; }
    }

    public interface IFieldInfo
    {
        uint InstanceFields { get; }
        uint StaticFields { get; }
        uint ThreadStaticFields { get; }
        ulong FirstField { get; }
    }

    public interface IFieldData
    {
        uint CorElementType { get; }
        uint SigType { get; }
        ulong TypeMethodTable { get; }

        ulong Module { get; }
        uint TypeToken { get; }

        uint FieldToken { get; }
        ulong EnclosingMethodTable { get; }
        uint Offset { get; }
        bool IsThreadLocal { get; }
        bool IsContextLocal { get; }
        bool IsStatic { get; }
        ulong NextField { get; }
    }

    public interface IEEClassData
    {
        ulong MethodTable { get; }
        ulong Module { get; }
    }

    public interface IDomainLocalModuleData
    {
        ulong AppDomainAddr { get; }
        ulong ModuleID { get; }

        ulong ClassData { get; }
        ulong DynamicClassTable { get; }
        ulong GCStaticDataStart { get; }
        ulong NonGCStaticDataStart { get; }
    }

    public interface IModuleData
    {
        ulong ImageBase { get; }
        ulong PEFile { get; }
        ulong LookupTableHeap { get; }
        ulong ThunkHeap { get; }
        object LegacyMetaDataImport { get; }
        ulong ModuleId { get; }
        ulong ModuleIndex { get; }
        ulong Assembly { get; }
        bool IsReflection { get; }
        bool IsPEFile { get; }
        ulong MetdataStart { get; }
        ulong MetadataLength { get; }
    }

    public interface IMethodDescData
    {
        ulong GCInfo { get; }
        ulong MethodDesc { get; }
        ulong Module { get; }
        uint MDToken { get; }
        ulong NativeCodeAddr { get; }
        ulong MethodTable { get; }
        int JITType { get; }  // MethodCompilationType
        ulong ColdStart { get; }
        uint ColdSize { get; }
        uint HotSize { get; }
    }

    public interface ICCWData
    {
        ulong IUnknown { get; }
        ulong Object { get; }
        ulong Handle { get; }
        ulong CCWAddress { get; }
        int RefCount { get; }
        int JupiterRefCount { get; }
        int InterfaceCount { get; }
    }

    public interface IRCWData
    {
        ulong IdentityPointer { get; }
        ulong UnknownPointer { get; }
        ulong ManagedObject { get; }
        ulong JupiterObject { get; }
        ulong VTablePtr { get; }
        ulong CreatorThread { get; }

        int RefCount { get; }
        int InterfaceCount { get; }

        bool IsJupiterObject { get; }
        bool IsDisconnected { get; }
    }

    public interface IAppDomainStoreData
    {
        ulong SharedDomain { get; }
        ulong SystemDomain { get; }
        int Count { get; }
    }

    public interface IObjectData
    {
        ulong DataPointer { get; }
        ulong ElementTypeHandle { get; }
        uint ElementType { get; }  // ClrElementType
        ulong RCW { get; }
        ulong CCW { get; }
    }

    public interface ISyncBlkData
    {
        bool Free { get; }
        ulong Address { get; }
        ulong Object { get; }
        ulong OwningThread { get; }
        bool MonitorHeld { get; }
        uint Recursion { get; }
        uint TotalCount { get; }
    }

    // This is consistent across all dac versions.  No need for interface.
    public struct CommonMethodTables
    {
        public ulong ArrayMethodTable;
        public ulong StringMethodTable;
        public ulong ObjectMethodTable;
        public ulong ExceptionMethodTable;
        public ulong FreeMethodTable;

        public bool Validate()
        {
            return ArrayMethodTable != 0 &&
                StringMethodTable != 0 &&
                ObjectMethodTable != 0 &&
                ExceptionMethodTable != 0 &&
                FreeMethodTable != 0;
        }
    };


    public interface IRWLockData
    {
        ulong Next { get; }
        int ULockID { get; }
        int LLockID { get; }
        int Level { get; }
    }

    public struct RWLockData : IRWLockData
    {
        public IntPtr pNext;
        public IntPtr pPrev;
        public int _uLockID;
        public int _lLockID;
        public Int16 wReaderLevel;

        public ulong Next
        {
            get { return (ulong)pNext.ToInt64(); }
        }

        public int ULockID
        {
            get { return _uLockID; }
        }

        public int LLockID
        {
            get { return _lLockID; }
        }


        public int Level
        {
            get { return wReaderLevel; }
        }
    }
}
