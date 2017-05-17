// (c) Copyright Microsoft Corporation.
// This source is subject to [###LICENSE_NAME###].
// Please see [###LICENSE_LINK###] for details.
// All other rights reserved.
//
// <autogenerated />
// The Visual Studio metadata is not subjected to same source analysis

//*****************************************************************************
// VS Attributes for unit testing
// Copyright(c) Microsoft Corporation, 2003
//*****************************************************************************

namespace  Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;

    /// <summary>
    /// TestContext class. This class should be fully abstract and not contain any 
    /// members. The adapter will implement the members. Users in the framework should
    /// only access this via a well-defined interface.
    /// </summary>
    public abstract partial class TestContext
    {
        /// <summary>
        /// Used to write trace messages while the test is running
        /// </summary>
        /// <param name="format">format string</param>
        /// <param name="args">the arguments</param>
        abstract public void WriteLine(string format, params object[] args);

        /// <summary>
        /// Adds a file name to the list in TestResult.ResultFileNames
        /// </summary>
        abstract public void AddResultFile(string fileName);

        /// <summary>
        /// Begins a timer with the specified name
        /// </summary>
        abstract public void BeginTimer(string timerName);

        /// <summary>
        /// Ends a timer with the specified name
        /// </summary>
        abstract public void EndTimer(string timerName);

        /// <summary>
        /// Per test properties
        /// </summary>
        /// <value></value>
        abstract public IDictionary Properties { get; }

        /// <summary>
        /// Current data row when test is used for data driven testing.
        /// </summary>
        abstract public DataRow DataRow { get; }

        /// <summary>
        /// Current data connection row when test is used for data driven testing.
        /// </summary>
        abstract public DbConnection DataConnection { get; }

        /// <summary>
        /// Gets the test logs directory.
        /// </summary>
        public virtual string TestLogsDir
        {
            get
            {
                return GetProperty<string>("TestLogsDir");
            }
        }

        /// <summary>
        /// Gets the test directory.
        /// </summary>
        public virtual string TestDir
        {
            get
            {
                return GetProperty<string>("TestDir");
            }
        }

        /// <summary>
        /// Gets the test deployment directory.
        /// </summary>
        public virtual string TestDeploymentDir
        {
            get
            {
                return GetProperty<string>("TestDeploymentDir");
            }
        }

        /// <summary>
        /// Gets the test name.
        /// </summary>
        public virtual string TestName
        {
            get
            {
                return GetProperty<string>("TestName");
            }
        }

        private T GetProperty<T>(string name)
            where T : class
        {
            object o = Properties[name];
            if (o != null && !(o is T)) // If o has a value, but it's not the right type
            {
//                Debug.Fail("How did an invalid value get in here?");
                throw new InvalidCastException(Resources.FrameworkMessages.InvalidPropertyType(name, o.GetType(), typeof(T)));
            }
            return (T)o;
        }

        /// <summary>
        /// Gets the CurrentTestOutcome.
        /// </summary>
        public virtual UnitTestOutcome CurrentTestOutcome 
        { 
            get { return UnitTestOutcome.Unknown; } 
        }
    }

    #region UnitTestOutcome
    /// <summary>
    /// Outcome of a test or a run.
    /// If a new successful state needs to be added you will need to modify 
    /// RunResultAndStatistics in TestRun and TestOutcomeHelper below.
    /// 
    /// NOTE: the order is important and is used for computing outcome for aggregations. 
    ///       More important outcomes come first. See TestOutcomeHelper.GetAggregationOutcome.
    /// </summary>
    public enum UnitTestOutcome : int
    {
        /// <summary>
        /// Test was executed, but there were issues.
        /// Issues may involve exceptions or failed assertions.
        /// </summary>
        Failed,

        /// <summary>
        /// Test has completed, but we can't say if it passed or failed.
        /// May be used for aborted tests...
        /// </summary>
        Inconclusive,

        /// <summary>
        /// Test was executed w/o any issues.
        /// </summary>
        Passed,

        /// <summary>
        /// Test is currently executing.
        /// </summary>
        InProgress,

        /// <summary>
        /// There was a system error while we were trying to execute a test.
        /// </summary>
        Error,

        /// <summary>
        /// The test timed out.
        /// </summary>
        Timeout,

        /// <summary>
        /// Test was aborted by the user. 
        /// </summary>
        Aborted,

        /// <summary>
        /// Test is in an unknown state
        /// </summary>
        Unknown
    }

    #endregion UnitTestOutcome

}

#region Type stubs

#if !DesktopCLR

namespace System.Data
{
    /// <summary>
    /// The data row.
    /// </summary>
    public class DataRow
    {
    }
}

namespace System.Data.Common
{
    /// <summary>
    /// The database connection.
    /// </summary>
    public class DbConnection
    {
    }
}

#endif

#endregion