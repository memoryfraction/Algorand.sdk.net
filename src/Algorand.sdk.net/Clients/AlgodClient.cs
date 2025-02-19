﻿using Algorand.SDK.Dotnet.Api;
using Algorand.SDK.Dotnet.Api.Models;
using Algorand.SDK.Dotnet.Api.Response;
using System;
using System.Threading.Tasks;

namespace Algorand.Process.Algod.Client
{
    public class AlgodClient
    {
        private readonly IAlgorandApiClient _apiClient;
        private string ApiVersion = "v1";

        public AlgodClient(IAlgorandApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void SetApiVersion(string apiVersion)
        {
            ApiVersion = apiVersion;
        }

        #region Health
        public async Task<ResponseBase<string>> GetHealthAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<string>("health");

                return ResponseBase<string>.Success("OK");
            }
            catch (Exception ex)
            {
                return ResponseBase<string>.Error(default, FormatError(ex));
            }
        }
        #endregion

        #region Account
        public async Task<ResponseBase<AlgoAccount>> GetAccountInformationAsync(string address)
        {
            try
            {
                var model = await _apiClient.GetAsync<AlgoAccount>($"{ApiVersion}/accounts/{address}");

                return ResponseBase<AlgoAccount>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AlgoAccount>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<Transaction>> GetTransactionInformationAsync(string address, string txId)
        {
            try
            {
                var model = await _apiClient.GetAsync<Transaction>($"{ApiVersion}/account/{address}/transaction/{txId}");

                return ResponseBase<Transaction>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<Transaction>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TransactionRoot>> GetTransactionsAsync(string address)
        {
            try
            {
                var model = await _apiClient.GetAsync<TransactionRoot>($"{ApiVersion}/account/{address}/transactions");

                return ResponseBase<TransactionRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TransactionRoot>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TruncatedTransactionRoot>> GetTransactionsPendingAsync(string address)
        {
            try
            {
                var model = await _apiClient.GetAsync<TruncatedTransactionRoot>($"{ApiVersion}/account/{address}/transactions/pending");

                return ResponseBase<TruncatedTransactionRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TruncatedTransactionRoot>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Amount
        public async Task<ResponseBase<AssetInfo>> GetAssetInformationAsync(string index)
        {
            try
            {
                var model = await _apiClient.GetAsync<AssetInfo>($"{ApiVersion}/asset/{index}");

                return ResponseBase<AssetInfo>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AssetInfo>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<AssetRoot>> GetAssetListAsync(int max, string index)
        {
            try
            {
                var model = await _apiClient.GetAsync<AssetRoot>($"{ApiVersion}/assets?max={max}&assetIdx={index}");

                return ResponseBase<AssetRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<AssetRoot>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Block
        public async Task<ResponseBase<Block>> GetBlockInformationAsync(int round)
        {
            try
            {
                var model = await _apiClient.GetAsync<Block>($"{ApiVersion}/block/{round}");

                return ResponseBase<Block>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<Block>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Ledger
        public async Task<ResponseBase<TotalSupply>> GetLedgerSupplyAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<TotalSupply>($"{ApiVersion}/ledger/supply");

                return ResponseBase<TotalSupply>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TotalSupply>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Status
        public async Task<ResponseBase<NodeStatus>> GetNodeStatusAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<NodeStatus>($"{ApiVersion}/status");

                return ResponseBase<NodeStatus>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<NodeStatus>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<NodeStatus>> GetNodeStatusAfterRoundAsync(int round)
        {
            try
            {
                var model = await _apiClient.GetAsync<NodeStatus>($"{ApiVersion}/status/wait-for-block-after/{round}");

                return ResponseBase<NodeStatus>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<NodeStatus>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Transactions
        public async Task<ResponseBase<Transaction>> GetSingleTransactionInformationAsync(string txId)
        {
            try
            {
                var model = await _apiClient.GetAsync<Transaction>($"{ApiVersion}/transaction/{txId}");

                return ResponseBase<Transaction>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<Transaction>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<FeeRoot>> GetSuggestedFeeAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<FeeRoot>($"{ApiVersion}/transactions/fee");

                return ResponseBase<FeeRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<FeeRoot>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TransactionParams>> GetTransactionParamsAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<TransactionParams>($"{ApiVersion}/transactions/params");

                return ResponseBase<TransactionParams>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TransactionParams>.Error(null, FormatError(ex));
            }
        }

        public async Task<ResponseBase<TruncatedTransactionRoot>> GetUnconfirmedTransactionAsync(string txId)
        {
            try
            {
                var model = await _apiClient.GetAsync<TruncatedTransactionRoot>($"{ApiVersion}/transactions/pending/{txId}");

                return ResponseBase<TruncatedTransactionRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<TruncatedTransactionRoot>.Error(null, FormatError(ex));
            }
        }
        #endregion

        #region Version
        public async Task<ResponseBase<VersionRoot>> GetVersionAsync()
        {
            try
            {
                var model = await _apiClient.GetAsync<VersionRoot>($"versions");

                return ResponseBase<VersionRoot>.Success(model);
            }
            catch (Exception ex)
            {
                return ResponseBase<VersionRoot>.Error(null, FormatError(ex));
            }
        }
        #endregion

        private string FormatError(Exception ex)
            => $"Exception: {ex.Message} | StackTrace: {ex.StackTrace}";
    }
}