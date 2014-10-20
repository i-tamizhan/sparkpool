﻿#region License
// 
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//     Copyright (C) 2013 - 2014, CoiniumServ Project - http://www.coinium.org
//     http://www.coiniumserv.com - https://github.com/CoiniumServ/CoiniumServ
// 
//     This software is dual-licensed: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//    
//     For the terms of this license, see licenses/gpl_v3.txt.
// 
//     Alternatively, you can license this software under a commercial
//     license or white-label it as set out in licenses/commercial.txt.
// 
#endregion

using System;
using System.Collections.Generic;
using CoiniumServ.Algorithms;
using CoiniumServ.Cryptology.Merkle;
using CoiniumServ.Daemon.Responses;
using CoiniumServ.Shares;
using CoiniumServ.Transactions;
using CoiniumServ.Utils.Numerics;
using Newtonsoft.Json;

namespace CoiniumServ.Jobs
{

    [JsonArray]
    public interface IJob : IEnumerable<object>
    {
        /// <summary>
        /// ID of the job. Use this ID while submitting share generated from this job.
        /// </summary>
        UInt64 Id { get; }

        /// <summary>
        /// Height of the block we are looking for.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Hash of previous block.
        /// </summary>
        string PreviousBlockHash { get; }

        string PreviousBlockHashReversed { get;  }

        /// <summary>
        /// Initial part of coinbase transaction.
        /// <remarks>The miner inserts ExtraNonce1 and ExtraNonce2 after this section of the coinbase. (https://www.btcguild.com/new_protocol.php)</remarks>
        /// </summary>
        string CoinbaseInitial { get; }

        /// <summary>
        /// Final part of coinbase transaction.
        /// <remarks>The miner appends this after the first part of the coinbase and the two ExtraNonce values. (https://www.btcguild.com/new_protocol.php)</remarks>
        /// </summary>
        string CoinbaseFinal { get; }

        /// <summary>
        /// Coin's block version.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Encoded current network difficulty.
        /// </summary>
        string EncodedDifficulty { get; }

        BigInteger Target { get; }

        /// <summary>
        /// Job difficulty.
        /// </summary>
        double Difficulty { get; }

        /// <summary>
        /// The current time. nTime rolling should be supported, but should not increase faster than actual time.
        /// </summary>
        string NTime { get; }

        /// <summary>
        /// When true, server indicates that submitting shares from previous jobs don't have a sense and such shares will be rejected. When this flag is set, miner should also drop all previous jobs, so job_ids can be eventually rotated. (http://mining.bitcoin.cz/stratum-mining)
        /// <remarks>f true, miners should abort their current work and immediately use the new job. If false, they can still use the current job, but should move to the new one after exhausting the current nonce range. (https://www.btcguild.com/new_protocol.php)</remarks>
        /// </summary>
        bool CleanJobs { get; set; }

        /// <summary>
        /// Creation time of the job.
        /// </summary>
        int CreationTime { get; }

        /// <summary>
        /// The assigned hash algorithm for the job.
        /// </summary>
        IHashAlgorithm HashAlgorithm { get; }

        /// <summary>
        /// Associated block template.
        /// </summary>
        IBlockTemplate BlockTemplate { get; }

        /// <summary>
        /// Associated generation transaction.
        /// </summary>
        IGenerationTransaction GenerationTransaction { get; }

        /// <summary>
        /// Merkle tree associated to blockTemplate transactions.
        /// </summary>
        IMerkleTree MerkleTree { get; }

        new IEnumerator<object> GetEnumerator();

        bool RegisterShare(IShare share);
    }
}