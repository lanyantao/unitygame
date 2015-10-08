#ifndef __SERVERTASK_H_
#define __SERVERTASK_H_


#include <ext/hash_map>
#include "zTCPServer.h"
#include "zTCPTask.h"
#include "zService.h"
#include "zMisc.h"
#include "zTime.h"
#include "SuperCommand.h"
#include "zType.h"
/**
 * \brief ��������������
 *
 * һ�����е�ÿһ������������Ҫ�͹�����������������
 * 
 */
class ServerTask : public zTCPTask
{

  public:

    /**
     * \brief ���캯��
     *
     * ���ڴ���һ����������������
     *
     * \param pool �������ӳ�ָ��
     * \param sock TCP/IP�׽ӿ�
     * \param addr ��ַ
     */
    ServerTask(
        zTCPTaskPool *pool,
        const int sock,
        const struct sockaddr_in *addr = NULL) : zTCPTask(pool,sock,addr)
    {
      wdServerID = 0;
      wdServerType = UNKNOWNSERVER;
      bzero(pstrIP,sizeof(pstrIP));
      wdPort = 0;

      OnlineNum = 0;

      sequenceOK = false;
      hasNotifyMe = false;
      hasprocessSequence = false;
    }

    /**
     * \brief ����������
     *
     */
    virtual ~ServerTask() {};

    int verifyConn();
    int waitSync();
    int recycleConn();
    void addToContainer();
    void removeFromContainer();
    bool uniqueAdd();
    bool uniqueRemove();
    bool msgParse(const Cmd::t_NullCmd *,const DWORD);
    void responseOther(const WORD wdServerID);

    /**
     * \brief ��ȡ���������
     *
     * \return ���������
     */
    const WORD getID() const
    {
      return wdServerID;
    }

    /**
     * \brief ��ȡ����������
     * \return ����������
     */
    const WORD getType() const
    {
      return wdServerType;
    }

    /**
     * \brief ���ط�������������
     * \return ��������������
     */
    const DWORD getOnlineNum() const
    {
      return OnlineNum;
    }

    /**
     * \brief ������һ�δ�������˳���ʱ��
     *
     * \return ����Ƿ�ɹ�
     */
    bool checkSequenceTime()
    {
      //����˳�����Ѿ�����ˣ�����Ҫ�ٴδ���
      if (sequenceOK)
        return false;

      //������δ����ļ��ʱ��
      zTime currentTime;
      if (lastSequenceTime.elapse(currentTime) > 2)
      {
        lastSequenceTime = currentTime;
        return true;
      }

      return false;
    }

  private:

    WORD wdServerID;          /**< ��������ţ�һ����Ψһ�� */
    WORD wdServerType;          /**< ���������ͣ�������ʵ����ʱ���Ѿ�ȷ�� */
    char pstrIP[MAX_IP_LENGTH];      /**< ������������ַ */
    WORD wdPort;            /**< �����������˿� */

    DWORD      OnlineNum;      /**< ��������ͳ�� */

    zTime lastSequenceTime;        /**< ���һ�δ�������˳���ʱ�� */
    bool sequenceOK;          /**< �Ƿ��Ѿ��������������˳�� */
    bool hasNotifyMe;
    bool hasprocessSequence;

    bool verify(WORD wdType,const char *pstrIP);
    bool verifyTypeOK(const WORD wdType,std::vector<ServerTask *> &sv);
    bool processSequence();
    bool notifyOther();
    bool notifyOther(WORD dstID);
    bool notifyMe();

    bool msgParse_Startup(const Cmd::t_NullCmd *pNullCmd,const DWORD nCmdLen);
    bool msgParse_Bill(const Cmd::t_NullCmd *pNullCmd,const DWORD nCmdLen);
    bool msgParse_Gateway(const Cmd::t_NullCmd *pNullCmd,const DWORD nCmdLen);
    bool msgParse_GmTool(const Cmd::t_NullCmd *pNullCmd,const DWORD nCmdLen);
    bool msgParse_CountryOnline(const Cmd::t_NullCmd *pNullCmd,const DWORD nCmdLen);
    bool msgParse_Battle(const Cmd::t_NullCmd *pNullCmd,const DWORD nCmdLen);
    bool msgParse_Scene(const Cmd::t_NullCmd *pNullCmd,const DWORD nCmdLen);

   struct key_hash
    {
      size_t operator()(const Cmd::Super::ServerEntry &x) const
      {
        __gnu_cxx::hash<WORD> H;
        return H(x.wdServerID);
      }
    };
    struct key_equal : public std::binary_function<Cmd::Super::ServerEntry,Cmd::Super::ServerEntry,bool>
    {
      bool operator()(const Cmd::Super::ServerEntry &s1,const Cmd::Super::ServerEntry &s2) const
      {
        return s1.wdServerID == s2.wdServerID;
      }
    };


    typedef __gnu_cxx::hash_map<Cmd::Super::ServerEntry,bool,key_hash,key_equal> Container;
    // ���ӽ����ķ������б�
    Container ses;

	const char* GetServerTypeName(const WORD wdServerType);
};




#endif